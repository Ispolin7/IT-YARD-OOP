using IT_YARD.Models;
using IT_YARD.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IT_YARD.Services.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public IT_YARD.Models.Product Product { get; set; }
        public IT_YARD.Models.Order Order { get; set; }
        public int Quantity { get; set; }
        public double PurchasePrice { get; set; }
        public Colors Color { get; set; }

        public OrderItem(IT_YARD.Models.OrderItem item, Product product, IT_YARD.Models.Order order)
        {
            Id = order.Id;
            Product = product;
            Order = order;
            Quantity = item.Quantity;
            PurchasePrice = item.PurchasePrice;
            Enum.GetName(typeof(Colors), this.Color);
        }
    }
}
