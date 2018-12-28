using System;
using System.Collections.Generic;
using System.Text;

namespace IT_YARD_OOP.Models
{
    class Order : EntityBase
    {
        public Customer Customer{get;}
        public DateTime OrderDate { get; }
        public Address ShippingAddress { get; }
        public List<OrderItem> OrderItems { get; }

        public Order(Customer customer, DateTime date, Address address, List<OrderItem> item) : base()
        {
            this.Customer = customer;
            this.OrderDate = date;
            this.ShippingAddress = address;
            this.OrderItems = item;
        }

        public override void DisplayEntityInfo()
        {
            Customer.DisplayEntityInfo();
            ShippingAddress.DisplayEntityInfo();
            foreach(OrderItem item in OrderItems)
            {
                item.DisplayEntityInfo();
            }
            Console.WriteLine($"Order date - {OrderDate}");
        }
    }
}
