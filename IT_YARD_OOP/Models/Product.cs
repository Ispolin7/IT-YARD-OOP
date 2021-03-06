﻿using System;
using System.Runtime.Serialization;

namespace IT_YARD.Models
{
    /// <summary>
    /// Product Model
    /// </summary>
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        /// <summary>
        /// Product constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        public Product(string name, string description, double price) : base()
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }
        public Product() { }

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
        public override bool Validate()
        {
            return !(
                string.IsNullOrWhiteSpace(this.Name) &&
                string.IsNullOrWhiteSpace(this.Description) &&
                double.IsNegative(this.Price)
            );
        }
    }
}
