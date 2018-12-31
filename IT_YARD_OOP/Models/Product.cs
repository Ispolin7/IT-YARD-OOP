using System;
using System.Collections.Generic;
using System.Text;

namespace IT_YARD_OOP.Models
{
    class Product : EntityBase
    {
        public string Name { get; }
        public string Description { get; }
        public double Price { get; }

        public Product(string name, string description, double price) : base()
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }

        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"Id - {this.Id}, name - {this.Name}, description - {this.Description}, price - {this.Price}");
        }

        public override bool Validate()
        {
            return !(
                string.IsNullOrWhiteSpace(this.Name) || 
                string.IsNullOrWhiteSpace(this.Description) || 
                double.IsNegative(this.Price)
            );
        }
    }
}
