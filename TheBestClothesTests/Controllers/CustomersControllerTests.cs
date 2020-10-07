using TheBestClothes.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TheBestClothes.Models;
using TheBestClothesTests.Mocks;

namespace TheBestClothes.Controllers.Tests
{
    [TestClass()]
    public class CustomersControllerTests
    {
        [TestMethod()]
        public void GetAllCustomersTest()
        {
            //Arrange
            var customers = new MockCustomersTest();
            var controller = new CustomersController(customers);

            //Act
            var response = (OkObjectResult)controller.Get();
            var result = response.StatusCode;
            var value = (IEnumerable<Customer>)response.Value;

            //Assert
            Assert.IsInstanceOfType(value, typeof(IEnumerable<Customer>));
            Assert.AreEqual(customers.Customers.Count, value.ToList().Count);
        }

        [TestMethod()]
        public void GetCustomersFromIntervalTest()
        {
            //Arrange
            var customers = new MockCustomersTest();
            var controller = new CustomersController(customers);

            //Act
            var response = (OkObjectResult)
                controller.Get("2020-09-10T23:15:56.452Z", "2020-10-05T01:21:25.452Z");
            var result = response.StatusCode;
            var value = (IEnumerable<Customer>)response.Value;

            //Assert
            Assert.AreEqual(200, result);
            Assert.IsNotNull(value);
            Assert.IsInstanceOfType(value, typeof(IEnumerable<Customer>));
            Assert.AreEqual(2, value.ToList().Count);
        }

        [TestMethod()]
        public void GetCustomersFromIntervalTest1()
        {
            //Arrange
            var customers = new MockCustomersTest();
            var controller = new CustomersController(customers);

            //Act
            var response = (BadRequestResult)
                controller.Get("gkrjgiejigejrg", "ksajiejiofjsoiajf");
            var result = response.StatusCode;

            //Assert
            Assert.AreEqual(400, result);
        }

        [TestMethod()]
        public void PostTest()
        {
            //Arrange
            var customers = new MockCustomersTest();
            var controller = new CustomersController(customers);
            var newCustomers = new List<Customer>
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
            };

            //Act
            var result = (CreatedResult) controller.Post(newCustomers);

            //Assert
            Assert.AreEqual(201, result.StatusCode);
            Assert.IsInstanceOfType(result.Value, typeof(IEnumerable<Customer>));

            foreach (var customer in newCustomers)
            {
                var current = customers.GetAllCustomers()
                    .Single(c => c.Id == customer.Id);
                Assert.AreEqual(customer.Age, current.Age);
                Assert.AreEqual(customer.VisitDateTime, current.VisitDateTime);
                Assert.AreEqual(customer.WasSatisfied, current.WasSatisfied);
                Assert.AreEqual(customer.Sex, current.Sex);
            }
        }

        [TestMethod()]
        public void PostTest1()
        {
            //Arrange
            var customers = new MockCustomersTest();
            var controller = new CustomersController(customers);
            var newCustomers = new List<Customer>
            {
                new Customer
                {
                    Id = 4,
                    Age = 45,
                    VisitDateTime = DateTime.Parse("2020-10-04T01:21:25.452Z"),
                    WasSatisfied = false,
                    Sex = 'T'
                },
                new Customer
                {
                    Id = 5,
                    Age = 23,
                    VisitDateTime = DateTime.Parse("2020-09-06T01:21:25.452Z"),
                    WasSatisfied = true,
                    Sex = 'M'
                }
            };

            //Act
            var result = (BadRequestResult) controller.Post(newCustomers);

            //Assert
            Assert.AreEqual(400, result.StatusCode);

            foreach (var customer in newCustomers)
            {
                var current = customers.GetAllCustomers()
                    .SingleOrDefault(c => c.Id == customer.Id);
                Assert.IsNull(current);
            }
        }
    }
}