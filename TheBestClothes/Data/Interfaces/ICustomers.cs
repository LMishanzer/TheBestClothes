using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheBestClothes.Models;

namespace TheBestClothes.Data.Interfaces
{
    /// <summary>
    /// Represents persistent storage of customers
    /// </summary>
    public interface ICustomers
    {
        /// <summary>
        /// Gets all customers from the storage
        /// </summary>
        /// <returns>List of customers</returns>
        IEnumerable<Customer> GetAllCustomers();

        /// <summary>
        /// Asynchronously gets all customers from the storage
        /// </summary>
        /// <returns>List of customers</returns>
        Task<IEnumerable<Customer>> GetAllCustomersAsync();

        /// <summary>
        /// Gets customers from a time interval from the storage
        /// </summary>
        /// <param name="start">Start of the interval</param>
        /// <param name="end">End of the interval</param>
        /// <returns>List of customers</returns>
        IEnumerable<Customer> GetCustomersFromInterval(DateTime start, DateTime end);

        /// <summary>
        /// Asynchronously gets customers from a time interval from the storage
        /// </summary>
        /// <param name="start">Start of the interval</param>
        /// <param name="end">End of the interval</param>
        /// <returns>List of customers</returns>
        Task<IEnumerable<Customer>> GetCustomersFromIntervalAsync(DateTime start, DateTime end);

        /// <summary>
        /// Add list of customers to the persistent storage
        /// </summary>
        /// <param name="customers">List of new customers</param>
        void AddCustomers(IEnumerable<Customer> customers);
    }
}
