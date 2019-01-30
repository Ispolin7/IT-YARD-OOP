using System;
using System.Reflection;
using System.Runtime.Serialization;


namespace IT_YARD.Models
{
    [DataContract]
    class OrderItem : EntityBase
    {
        public static string ClassName = MethodBase.GetCurrentMethod().DeclaringType.ToString();
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
