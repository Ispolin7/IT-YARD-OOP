using System;
using System.Collections.Generic;
using System.Text;

namespace IT_YARD.Models
{
    /// <summary>
    /// Product Model
    /// </summary>
    class Product : EntityBase
    {
        public string Name { get; }
        public string Description { get; }
        public double Price { get; }

        /// <summary>
        /// Product constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        public Product(string name, string description, double price) 
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }

        /// <summary>
        /// Show entity information
        /// </summary>
        public new void DisplayEntityInfo()
        {
            Console.WriteLine($"Name - {this.Name}, description - {this.Description}, price - {this.Price}");
        }

        /// <summary>
        /// Validate product properties
        /// </summary>
        /// <returns>true if everything is correct</returns>
        public new bool Validate()
        {
            return !(
                string.IsNullOrWhiteSpace(this.Name) &&
                string.IsNullOrWhiteSpace(this.Description) &&
                double.IsNegative(this.Price)
            );
        }
    }
}
