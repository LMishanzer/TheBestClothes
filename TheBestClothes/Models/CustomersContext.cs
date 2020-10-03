using Microsoft.EntityFrameworkCore;

namespace TheBestClothes.Models
{
    /// <summary>
    /// Class for connection with customers database
    /// </summary>
    public class CustomersContext : DbContext
    {
        /// <summary>
        /// Represents table "Customers" 
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        public CustomersContext() { }

        public CustomersContext(DbContextOptions<CustomersContext> options) 
            : base(options) { }
    }
}
