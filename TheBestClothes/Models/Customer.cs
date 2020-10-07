using System;
using System.ComponentModel.DataAnnotations;

namespace TheBestClothes.Models
{
    /// <summary>
    /// Model of a customer
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Personal id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date and time of visiting store
        /// </summary>
        [Required]
        public DateTime VisitDateTime { get; set; }

        /// <summary>
        /// Age of the customer
        /// </summary>
        [Required]
        public int Age { get; set; }

        /// <summary>
        /// Was customer satisfied or not
        /// </summary>
        [Required]
        public bool WasSatisfied { get; set; }

        /// <summary>
        /// Customer's gender
        /// </summary>
        [Required]
        public char Sex { get; set; }
    }
}
