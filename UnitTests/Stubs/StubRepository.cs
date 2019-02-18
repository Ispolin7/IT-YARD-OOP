using IT_YARD.Models;
using IT_YARD.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Stubs
{
    public class StubRepository
    {
        public Repository<Customer> Customers { get; set; }
        public Repository<Order> Orders { get; set; }
        public Repository<OrderItem> Items { get; set; }
        public Repository<Product> Products { get; set; }

        public Repository<Customer> СustomersRepositoryInitialization()
        {
            this.Customers = new Repository<Customer>();

            this.Customers.Items.Add(
                Guid.Parse("edb050f5-ca3b-4381-a4ba-7b57ebeb108f"),
                new Customer()
                {
                    Id = Guid.Parse("edb050f5-ca3b-4381-a4ba-7b57ebeb108f"),
                    FirstName = "Poor",
                    LastName = "Gaper",
                    Email = "gaper@mail.com",
                    Gender = 1
                }
            );
            this.Customers.Items.Add(
                Guid.Parse("02aaa926-2d33-4935-9e55-478d4b10d988"),
                new Customer()
                {
                    Id = Guid.Parse("02aaa926-2d33-4935-9e55-478d4b10d988"),
                    FirstName = "Rich",
                    LastName = "Buyer",
                    Email = "buyer@mail.com",
                    Gender = 2
                }
            );
            this.Customers.Items.Add(
                Guid.Parse("02aaa926-2d33-4935-9e55-478d4b10d777"),
                new Customer() {
                    Id = Guid.Parse("02aaa926-2d33-4935-9e55-478d4b10d777"),
                    FirstName = "Stray",
                    LastName = "Guy",
                    Email = "stray@mail.com",
                    Gender = 1
                }
            );
            return this.Customers;
        }

        public Repository<Order> OrdersRepositoryInitialization()
        {
            this.Orders = new Repository<Order>();
            //var address = new Address("Street", "25-B", "Poltava", "DC Columbia", "777", "Trinidad");

            this.Orders.Items.Add(
                Guid.Parse("99a9bb22-f679-4fa3-bba7-8ce5949f7323"),
                new Order()
                {
                    Id = Guid.Parse("99a9bb22-f679-4fa3-bba7-8ce5949f7323"),
                    CustomerId = Guid.Parse("edb050f5-ca3b-4381-a4ba-7b57ebeb108f"),
                    OrderDate = DateTime.Now
                }
            );
            this.Orders.Items.Add(
                Guid.Parse("9a695527-f0b3-4e85-b21d-10018621f896"),
                new Order()
                {
                    Id = Guid.Parse("9a695527-f0b3-4e85-b21d-10018621f896"),
                    CustomerId = Guid.Parse("edb050f5-ca3b-4381-a4ba-7b57ebeb108f"),
                    OrderDate = DateTime.Now
                }
            );
            this.Orders.Items.Add(
                Guid.Parse("e83facfb-d63e-4626-9e33-31da79ce84fe"),
                new Order()
                {
                    Id = Guid.Parse("e83facfb-d63e-4626-9e33-31da79ce84fe"),
                    CustomerId = Guid.Parse("02aaa926-2d33-4935-9e55-478d4b10d988"),
                    OrderDate = DateTime.Now
                }
            );

            return this.Orders;
        }

        public Repository<OrderItem> ItemRepositoryInitialization()
        {
            this.Items = new Repository<OrderItem>();

            this.Items.Items.Add(
                Guid.Parse("9af68d7c-87f1-4d06-828b-78f91d0418e8"),
                new OrderItem()
                {
                    Id = Guid.Parse("9af68d7c-87f1-4d06-828b-78f91d0418e8"),
                    ProductId = Guid.Parse("9af68d7c-87f1-4d06-828b-78f91d0418e8"),
                    OrderId = Guid.Parse("99a9bb22-f679-4fa3-bba7-8ce5949f7323"),
                    Quantity = 1,
                    PurchasePrice = 100500.0,
                    Color = 8
                }
            );
            this.Items.Items.Add(
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
            return this.Items;
        }

        public Repository<Product> ProductRepositoryInitialization()
        {
            this.Products = new Repository<Product>();
          
            this.Products.Items.Add(
                Guid.Parse("9af68d7c-87f1-4d06-828b-78f91d0418e8"),
                new Product()
                {
                    Id = Guid.Parse("9af68d7c-87f1-4d06-828b-78f91d0418e8"),
                    Name = "C#",
                    Description = "How to learn a language in 30 minutes",
                    Price = 100500.0
                }
            );
            this.Products.Items.Add(
                Guid.Parse("c0ca2995-903c-4031-9ce4-0eccd9d22db0"),
                new Product()
                {
                    Id = Guid.Parse("c0ca2995-903c-4031-9ce4-0eccd9d22db0"),
                    Name = "Coding guru",
                    Description = "How to write code by thought",
                    Price = 9.99
                }
            );
            return this.Products;
        }
    }
}
