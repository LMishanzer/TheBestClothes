using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestClothes.Data.Interfaces;
using TheBestClothes.Models;

namespace TheBestClothesTests.Mocks
{
    class MockCustomersTest : ICustomers
    {
        public List<Customer> Customers { get; private set; } = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                Age = 15,
                VisitDateTime = DateTime.Parse("2020-09-04T23:18:45.452Z"),
                WasSatisfied = true,
                Sex = 'M'
            },
            new Customer
            {
                Id = 2,
                Age = 87,
                VisitDateTime = DateTime.Parse("2020-09-14T19:36:13.452Z"),
                WasSatisfied = false,
                Sex = 'F'
            },
            new Customer
            {
                Id = 3,
                Age = 18,
                VisitDateTime = DateTime.Parse("2020-10-05T01:21:25.452Z"),
                WasSatisfied = true,
                Sex = 'F'
            },
        };

        public IEnumerable<Customer> GetAllCustomers()
        {
            return Customers.ToList();
        }

        public IEnumerable<Customer> GetCustomersFromInterval(DateTime start, DateTime end)
        {
            return Customers.Where(customer => customer.VisitDateTime >= start
                                                && customer.VisitDateTime <= end)
                .ToList();
        }

        public bool AddCustomers(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                if (customer.Sex != 'M' && customer.Sex != 'F')
                    return false;
            }

            try
            {
                Customers.AddRange(customers);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
