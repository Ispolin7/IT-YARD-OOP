using System;
using System.Collections.Generic;
using System.Text;

namespace IT_YARD_OOP.Models
{
    class OrderItem : EntityBase
    {
        public Product Product { get; }
        public int Quantity { get; }
        public double PurchasePrice { get; }

        public OrderItem(Product product, int quantity) : base()
        {
            this.Product = product;
            this.Quantity = quantity;
            this.PurchasePrice = quantity * this.Product.Price;
        }

        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"Id - {this.Id}, name - {this.Product.Name}, quantity - {this.Quantity}, price - {this.PurchasePrice}");
        }

        public override bool Validate()
        {
            return (this.Quantity > 0);
        }
    }

}
