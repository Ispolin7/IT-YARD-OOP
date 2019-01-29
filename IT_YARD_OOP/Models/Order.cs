using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace IT_YARD.Models
{
    /// <summary>
    /// Product order
    /// </summary>
    class Order : EntityBase
    {
        public static string ClassName = MethodBase.GetCurrentMethod().DeclaringType.ToString();
        /// <summary>
        /// Class properties
        /// </summary>
        public Guid CustomerId { get; }    
        public Address ShippingAddress { get; }
        public List<Guid> OrderItemsId { get; }
        public DateTime OrderDate { get; }

        /// <summary>
        /// Order constructor
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="address"></param>
        /// <param name="items"></param>
        public Order(Guid customerId, Address address) : base()
        {
            this.CustomerId = customerId;
            this.OrderDate = DateTime.UtcNow;
            this.ShippingAddress = address;
        }

        /// <summary>
        /// Display order information
        /// </summary>
        public new void DisplayEntityInfo()
        {
            Console.WriteLine("Order information:");
            Console.WriteLine($"Customer id - {this.CustomerId}");
            Console.Write($"Shiping address - ");
            ShippingAddress.DisplayEntityInfo();
            Console.WriteLine($"Order date - {OrderDate}");
        }

        /// <summary>
        /// Validate order properties
        /// </summary>
        /// <returns>true if everything is correct</returns>
        public override bool Validate()
        {
            return (ShippingAddress.Validate());
        }
    }
}
