using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheBestClothes.Data.Interfaces;
using TheBestClothes.Models;

namespace TheBestClothes.Data.Mocks
{
    public class MockCustomers : ICustomers
    {
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

        public async void AddCustomer(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async void AddCustomers(IEnumerable<Customer> customers)
        {
            await _context.Customers.AddRangeAsync(customers);
            await _context.SaveChangesAsync();
        }
    }
}
