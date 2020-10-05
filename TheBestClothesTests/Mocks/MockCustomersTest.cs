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
        private readonly List<Customer> _customers = new List<Customer>
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
            return _customers;
        }

        public Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return Task.Run(GetAllCustomers);
        }

        public IEnumerable<Customer> GetCustomersFromInterval(DateTime start, DateTime end)
        {
            return _customers.Where(customer => customer.VisitDateTime >= start
                                                && customer.VisitDateTime <= end);
        }

        public Task<IEnumerable<Customer>> GetCustomersFromIntervalAsync(DateTime start, DateTime end)
        {
            return Task.Run(() => GetCustomersFromInterval(start, end));
        }

        public void AddCustomers(IEnumerable<Customer> customers)
        {
            _customers.AddRange(customers);
        }
    }
}
