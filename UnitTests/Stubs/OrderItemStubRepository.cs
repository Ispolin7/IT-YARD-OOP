using IT_YARD.Models;
using IT_YARD.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Stubs
{
    class OrderItemStubRepository
    {
        public Repository<OrderItem> OrderItems { get; set; }
        public OrderItem TestOrderItem { get; set; }

        public OrderItemStubRepository()
        {
            this.TestOrderItem = new OrderItem()
            {
                Id = Guid.Parse("9af68d7c-87f1-4d06-828b-78f91d0418e8"),
                ProductId = Guid.Parse("9af68d7c-87f1-4d06-828b-78f91d0418e8"),
                OrderId = Guid.Parse("99a9bb22-f679-4fa3-bba7-8ce5949f7323"),
                Quantity = 1,
                PurchasePrice = 100500.0,
                Color = 8,
                IsDeleted = false
            };

            this.OrderItems = new Repository<OrderItem>();
            this.OrderItems.Items.Add(TestOrderItem.Id, TestOrderItem);
            this.OrderItems.Items.Add(
                Guid.Parse("c0ca2995-903c-4031-9ce4-0eccd9d22db0"),
                new OrderItem()
                {
                    Id = Guid.Parse("c0ca2995-903c-4031-9ce4-0eccd9d22db0"),
                    ProductId = Guid.Parse("c0ca2995-903c-4031-9ce4-0eccd9d22db0"),
                    OrderId = Guid.Parse("99a9bb22-f679-4fa3-bba7-8ce5949f7323"),
                    Quantity = 2,
                    PurchasePrice = 19.98,
                    Color = 1
                }
            );
        }
    }
}
