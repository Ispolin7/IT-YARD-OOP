using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IT_YARD.Models
{
    /// <summary>
    /// Product order
    /// </summary>
    [DataContract]
    class Order : EntityBase
    {
        /// <summary>
        /// Class properties
        /// </summary>
        [DataMember]
        public Guid CustomerId { get; set; }
        [DataMember]
        public Address ShippingAddress { get; set; }
        [DataMember]
        public List<Guid> OrderItemsId { get; set; }
        [DataMember]
        public DateTime OrderDate { get; set; }

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
