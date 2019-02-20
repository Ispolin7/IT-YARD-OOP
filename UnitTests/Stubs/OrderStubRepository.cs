using IT_YARD.Models;
using IT_YARD.Repositories;
using System;

namespace UnitTests.Stubs
{
    public class OrderStubRepository
    {
        public Repository<Order> Orders { get; set; }
        public Order TestOrder { get; set; }

        public OrderStubRepository()
        {
            this.TestOrder = new Order
            {
                Id = Guid.Parse("99a9bb22-f679-4fa3-bba7-8ce5949f7323"),
                CustomerId = Guid.Parse("edb050f5-ca3b-4381-a4ba-7b57ebeb108f"),
                OrderDate = DateTime.Now
            };

            this.Orders = new Repository<Order>();
            this.Orders.Items.Add(TestOrder.Id, TestOrder);
            this.Orders.Items.Add(
                Guid.Parse("9a695527-f0b3-4e85-b21d-10018621f896"),
                new Order
                {
                    Id = Guid.Parse("9a695527-f0b3-4e85-b21d-10018621f896"),
                    CustomerId = Guid.Parse("edb050f5-ca3b-4381-a4ba-7b57ebeb108f"),
                    OrderDate = DateTime.Now
                }
            );
            this.Orders.Items.Add(
                Guid.Parse("e83facfb-d63e-4626-9e33-31da79ce84fe"),
                new Order
                {
                    Id = Guid.Parse("e83facfb-d63e-4626-9e33-31da79ce84fe"),
                    CustomerId = Guid.Parse("02aaa926-2d33-4935-9e55-478d4b10d988"),
                    OrderDate = DateTime.Now
                }
            );
        }
    }
}
