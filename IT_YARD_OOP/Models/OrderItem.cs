using System;
using IT_YARD.Common;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace IT_YARD.Models
{
    public class OrderItem : EntityBase
    {
        
        /// <summary>
        /// OrderItem properties
        /// </summary>
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public double PurchasePrice { get; set; }
        public int Color { get; set; }

        public IEnumerable<Product> Products { get; set; }

        /// <summary>
        /// OrderItem constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public OrderItem(Product product, int quantity, Guid orderId, int color) : base() 
        {             
            this.ProductId = product.Id;
            this.OrderId = orderId;
            this.Quantity = quantity;
            this.PurchasePrice = quantity * product.Price;
            this.Color = color;
        }
        public OrderItem() { }

        /// <summary>
        /// Show OrderItem information
        /// </summary>
        public new void DisplayEntityInfo()
        {
            Console.WriteLine($"Product Id - {this.ProductId}, quantity - {this.Quantity}, price - {this.PurchasePrice}");
        }

        /// <summary>
        /// Validate OrderItem properties
        /// </summary>
        /// <returns>true if everything is correct</returns>
        public override bool Validate()
        {
            return (this.PurchasePrice > 0 && Enum.IsDefined(typeof(Colors), this.Color));
        }
    }

}
