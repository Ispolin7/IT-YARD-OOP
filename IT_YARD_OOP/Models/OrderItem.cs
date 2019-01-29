using System;
using System.Collections.Generic;
using System.Text;
using IT_YARD.Repositories;
using System.Reflection;


namespace IT_YARD.Models
{
    class OrderItem : EntityBase
    {
        public static string ClassName = MethodBase.GetCurrentMethod().DeclaringType.ToString();
        /// <summary>
        /// OrderItem properties
        /// </summary>
        public Guid ProductId { get; }
        public Guid OrderId { get; }
        public int Quantity { get; }
        public double PurchasePrice { get; }

        /// <summary>
        /// OrderItem constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public OrderItem(Product product, int quantity, Guid orderId) : base() 
        {   
            if(product != null)
            {
                this.ProductId = product.Id;
                this.OrderId = orderId;
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
        public override bool Validate()
        {
            return (this.PurchasePrice > 0);
        }
    }

}
