using System;

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
        public DateTime VisitDateTime { get; set; }

        /// <summary>
        /// Age of the customer
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Was customer satisfied or not
        /// </summary>
        public bool WasSatisfied { get; set; }

        /// <summary>
        /// Customer's gender
        /// </summary>
        public char Sex { get; set; }
    }
}
