using IT_YARD.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IT_YARD.Services.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Address ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public IEnumerable<IT_YARD.Models.OrderItem> Items { get; set; }

        public Order(IT_YARD.Models.Order order, IEnumerable<IT_YARD.Models.OrderItem> items)
        {
            Id = order.Id;
            ShippingAddress = order.ShippingAddress;
            OrderDate = order.OrderDate;
            Items = items;
        }
    }
}
