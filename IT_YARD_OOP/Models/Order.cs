using System;
using IT_YARD.Common;
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
        //[DataMember]
        //public List<Guid> OrderItemsId { get; set; }
        [DataMember]
        public DateTime OrderDate { get; set; }

        public List<OrderItem> Items { get; set; }
        public static JsonSerializer<OrderItem> relatedItems = new JsonSerializer<OrderItem>();

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
            this.Items = new List<OrderItem>();
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
            return ShippingAddress.Validate();
        }

        /// <summary>
        /// Get related products list
        /// </summary>
        /// <returns>update Products property</returns>
        public override bool AppendRelated()
        {
            if (this.Items == null || Items.Count > 0)
            {
                this.Items = new List<OrderItem>();
            }
            //relatedItems.Read();
            //Items.Clear();            
            foreach (OrderItem item in relatedItems.Read())
            {
                //foreach(Guid itemId in OrderItemsId)
                //{
                    if (item.OrderId == this.Id)
                    {
                        item.AppendRelated();
                        Items.Add(item);
                    }
                //}                
            }
            return true;
        }
    }
}
