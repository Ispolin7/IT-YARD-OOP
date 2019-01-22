using System;
using System.Collections.Generic;
using System.Text;

namespace IT_YARD.Models
{
    /// <summary>
    /// Product order
    /// </summary>
    class Order : EntityBase
    {
        /// <summary>
        /// Class properties
        /// </summary>
        public int CustomerId { get; }    
        public Address ShippingAddress
        {
            get
            {
                return ShippingAddress;
            }
            set
            {
                // validate Address instance
                // TODO Stack Owerflow Exception!!!
                //if (value.Validate())
                //{
                //    ShippingAddress = value;
                //}
                //else
                //{
                //    ShippingAddress = null;
                //}
            }
        }

        public List<int> OrderItemsId { get; }
        public DateTime OrderDate { get; }

        /// <summary>
        /// Order constructor
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="address"></param>
        /// <param name="items"></param>
        public Order(int customerId, Address address, List<int> items) 
        {
            this.CustomerId = customerId;
            this.OrderDate = DateTime.UtcNow;
            this.ShippingAddress = address;
            this.OrderItemsId = items;
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
        public new bool Validate()
        {
            return !(
                this.CustomerId <= 0 &&
                this.ShippingAddress == null &&
                OrderItemsId.Count == 0
                );
        }
    }
}
