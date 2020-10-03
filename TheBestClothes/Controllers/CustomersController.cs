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
        private readonly ICustomers _customers;

        public CustomersController(ICustomers customers)
        {
            _customers = customers;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _customers.GetAllCustomersAsync();
        }

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

        //POST api/<CustomersController>
        [HttpPost]
        public void Post(IEnumerable<Customer> customers)
        {
            _customers.AddCustomers(customers);
        }
    }
}
