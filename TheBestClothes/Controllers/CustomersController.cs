using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBestClothes.Data.Interfaces;
using TheBestClothes.Models;

namespace TheBestClothes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        /// <summary>
        /// Instance working with storage
        /// </summary>
        private readonly ICustomers _customers;

        public CustomersController(ICustomers customers)
        {
            _customers = customers;
        }

        /// <summary>
        /// Returns all customers from storage
        /// </summary>
        /// <returns>List of all saved customers</returns>
        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _customers.GetAllCustomersAsync();
        }

        /// <summary>
        /// Returns customers from a time interval
        /// </summary>
        /// <param name="start">Start of the interval</param>
        /// <param name="end">End of the interval</param>
        /// <returns>List of customers</returns>
        // GET api/<CustomersController>/5
        [HttpGet("{start}/{end}")]
        public async Task<IEnumerable<Customer>> Get(string start, string end)
        {
            try
            {
                var culture = CultureInfo.CreateSpecificCulture("en-EN");
                DateTime startTime = DateTime.Parse(start, culture);
                DateTime endTime = DateTime.Parse(end, culture);

                return await _customers.GetCustomersFromIntervalAsync(startTime, endTime);
            }
            catch (FormatException e)
            {
                return null;
            }
        }

        /// <summary>
        /// Takes list of customers and saves them to the storage
        /// </summary>
        /// <param name="customers">List of customers</param>
        //POST api/<CustomersController>
        [HttpPost]
        public void Post(IEnumerable<Customer> customers)
        {
            _customers.AddCustomers(customers);
        }
    }
}
