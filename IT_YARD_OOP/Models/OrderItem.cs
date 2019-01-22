using System;
using System.Collections.Generic;
using System.Text;
using IT_YARD.Repositories;


namespace IT_YARD.Models
{
    class OrderItem : EntityBase
    {
        /// <summary>
        /// OrderItem properties
        /// </summary>
        public int ProductId { get; }
        public int Quantity { get; }
        public double PurchasePrice { get; }

        /// <summary>
        /// OrderItem constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public OrderItem(int id, Product product, int quantity) 
        {   
            if(product != null)
            {
                this.ProductId = id;
                this.Quantity = quantity;
                this.PurchasePrice = quantity * product.Price;
            }                 
        }

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
        public new bool Validate()
        {
            return (this.Quantity > 0);
        }
    }

}
