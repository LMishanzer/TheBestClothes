using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TheBestClothes.Models;
using TheBestClothesTests.Mocks;

namespace TheBestClothes.Controllers.Tests
{
    [TestClass()]
    public class CustomersControllerTests
    {
        private readonly MockCustomersTest _customers = new MockCustomersTest();

        [TestMethod()]
        public void GetAllCustomersTest()
        {
            //Arrange
            var controller = new CustomersController(_customers);

            //Act
            var result = controller.Get().Result;

            //Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Customer>));
            Assert.AreEqual(3, result.ToList().Count);
        }

        [TestMethod()]
        public void GetCustomersFromIntervalTest()
        {
            //Arrange
            var controller = new CustomersController(_customers);

            //Act
            var result =
                controller.Get("2020-09-10T23:15:56.452Z", "2020-10-05T01:21:25.452Z").Result;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Customer>));
            Assert.AreEqual(2, result.ToList().Count);
        }

        [TestMethod()]
        public void PostTest()
        {
            //Arrange
            var controller = new CustomersController(_customers);

            //Act
            controller.Post(new List<Customer>
            {
                new Customer
                {
                    Id = 4,
                    Age = 45,
                    VisitDateTime = DateTime.Parse("2020-10-04T01:21:25.452Z"),
                    WasSatisfied = false,
                    Sex = 'M'
                },
                new Customer
                {
                    Id = 5,
                    Age = 23,
                    VisitDateTime = DateTime.Parse("2020-09-06T01:21:25.452Z"),
                    WasSatisfied = true,
                    Sex = 'M'
                }
            });

            //Assert
            var first = _customers.GetAllCustomers().Single(customer => customer.Id == 4);
            Assert.AreEqual(45, first.Age);
            Assert.AreEqual(DateTime.Parse("2020-10-04T01:21:25.452Z"), first.VisitDateTime);
            Assert.AreEqual(false, first.WasSatisfied);
            Assert.AreEqual('M', first.Sex);

            var second = _customers.GetAllCustomers().Single(customer => customer.Id == 5);
            Assert.AreEqual(23, second.Age);
            Assert.AreEqual(DateTime.Parse("2020-09-06T01:21:25.452Z"), second.VisitDateTime);
            Assert.AreEqual(true, second.WasSatisfied);
            Assert.AreEqual('M', first.Sex);
        }
    }
}