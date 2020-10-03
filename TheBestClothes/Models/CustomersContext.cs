using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TheBestClothes.Models
{
    public class CustomersContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomersContext() { }

        public CustomersContext(DbContextOptions<CustomersContext> options) 
            : base(options) { }
    }
}
