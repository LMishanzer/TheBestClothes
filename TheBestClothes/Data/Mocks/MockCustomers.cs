using System;
using System.Collections.Generic;
using System.Linq;
using TheBestClothes.Data.Interfaces;
using TheBestClothes.Models;

namespace TheBestClothes.Data.Mocks
{
    /// <summary>
    /// Class for working with database
    /// </summary>
    public class MockCustomers : ICustomers
    {
        /// <summary>
        /// Database instance
        /// </summary>
        private readonly CustomersContext _context;

        public MockCustomers(CustomersContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public IEnumerable<Customer> GetCustomersFromInterval(DateTime start, DateTime end)
        {
            return _context.Customers.Where(customer =>
                customer.VisitDateTime >= start && customer.VisitDateTime <= end)
                .ToList();
        }

        public bool AddCustomers(IEnumerable<Customer> customers)
        {
            try
            {
                _context.Customers.AddRange(customers);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
