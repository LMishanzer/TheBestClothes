using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public IEnumerable<Customer> GetCustomersFromInterval(DateTime start, DateTime end)
        {
            return _context.Customers.Where(customer =>
                customer.VisitDateTime >= start && customer.VisitDateTime <= end)
                .ToList();
        }

        public async Task<IEnumerable<Customer>> GetCustomersFromIntervalAsync
            (DateTime start, DateTime end)
        {
            return await _context.Customers.Where(customer =>
                customer.VisitDateTime >= start && customer.VisitDateTime <= end)
                .ToListAsync();
        }

        public void AddCustomers(IEnumerable<Customer> customers)
        {
            _context.Customers.AddRange(customers);
            _context.SaveChanges();
        }
    }
}
