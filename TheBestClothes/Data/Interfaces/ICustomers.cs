using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheBestClothes.Models;

namespace TheBestClothes.Data.Interfaces
{
    public interface ICustomers
    {
        IEnumerable<Customer> GetAllCustomers();
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        IEnumerable<Customer> GetCustomersFromInterval(DateTime start, DateTime end);
        Task<IEnumerable<Customer>> GetCustomersFromIntervalAsync(DateTime start, DateTime end);
        void AddCustomer(Customer customer);
        void AddCustomers(IEnumerable<Customer> customers);
    }
}
