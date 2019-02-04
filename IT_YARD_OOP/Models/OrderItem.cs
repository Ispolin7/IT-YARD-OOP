using System;
using IT_YARD.Common;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace IT_YARD.Models
{
    [DataContract]
    class OrderItem : EntityBase
    {
        /// <summary>
        /// OrderItem properties
        /// </summary>
        [DataMember]
        public Guid ProductId { get; set; }
        [DataMember]
        public Guid OrderId { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public double PurchasePrice { get; set; }

        public List<Product> Products { get; set; }
        public static JsonSerializer<Product> relatedProducts = new JsonSerializer<Product>();

        /// <summary>
        /// OrderItem constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public OrderItem(Product product, int quantity, Guid orderId) : base() 
        {             
            this.ProductId = product.Id;
            this.OrderId = orderId;
            this.Quantity = quantity;
            this.PurchasePrice = quantity * product.Price;
            this.Products = new List<Product>();
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

        /// <summary>
        /// Get related products list
        /// </summary>
        /// <returns>update Products property</returns>
        public override bool AppendRelated()
        {
            if (this.Products == null || Products.Count > 0)
            {
                this.Products = new List<Product>();
            }

            foreach (Product product in relatedProducts.Read())
            {
                if(product.Id == this.ProductId)
                {
                    Products.Add(product);
                }
            }
            return true;
        }
    }

}
