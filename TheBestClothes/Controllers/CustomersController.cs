using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheBestClothes.Data.Interfaces;
using TheBestClothes.Models;

namespace TheBestClothes.Controllers
{
    [Produces("application/json")]
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
        /// <response code="200">Returns requested items</response>
        // GET: api/<CustomersController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return new OkObjectResult(_customers.GetAllCustomers());
        }

        /// <summary>
        /// Returns customers from a time interval
        /// </summary>
        /// <param name="start">Start of the interval</param>
        /// <param name="end">End of the interval</param>
        /// <returns>List of customers</returns>
        /// <response code="200">Returns requested items</response>
        /// <response code="400">Bad parameters</response>
        // GET api/<CustomersController>/5
        [HttpGet("{start}/{end}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(string start, string end)
        {
            try
            {
                var culture = CultureInfo.CreateSpecificCulture("en-EN");
                DateTime startTime = DateTime.Parse(start, culture);
                DateTime endTime = DateTime.Parse(end, culture);

                return new OkObjectResult(_customers.GetCustomersFromInterval(startTime, endTime));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        /// <summary>
        /// Takes list of customers and saves them to the storage
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     [
        ///         {
        ///             "VisitDateTime": "2020-10-01T10:00:12",
        ///             "Age": 63,
        ///             "WasSatisfied": false,
        ///             "Sex": "F"
        ///         },
        ///         {
        ///             "VisitDateTime": "2020-10-01T10:00:12",
        ///             "Age": 19,
        ///             "WasSatisfied": true,
        ///             "Sex": "M"
        ///         }
        ///     ]
        /// </remarks>
        /// <param name="customers">List of customers</param>
        /// <response code="201">Customers were added</response>
        /// <response code="400">Bad request. Customers were not added</response>
        //POST api/<CustomersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(IEnumerable<Customer> customers)
        {
            if (_customers.AddCustomers(customers))
                return Created("Customers added", customers);

            return BadRequest();
        }
    }
}
