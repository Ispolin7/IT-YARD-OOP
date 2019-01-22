using System;
using IT_YARD.Models;
using IT_YARD.Repositories;
using System.Collections.Generic;

namespace IT_YARD
{
    class Program
    {
        static void Main(string[] args)
        {
            // add new address
            var firstAddress = new Address(1, "Street", "25-B", "Poltava", "DC Columbia", "777", "Trinidad");
            
            // create user repository and add users
            var firstUser = new User("Starter", "password");
            var secondUser = new User("Mega", "Hacker!");
            var userRepo = new Repository<User>();
            userRepo.Insert(firstUser);
            userRepo.Insert(secondUser);
            
            // create customer repository and add customers
            var customerRepo = new Repository<Customer>();
            var firstCustomer = new Customer("Rich", "Buyer", "buyer@mail.com", 1, 1);
            firstCustomer.AddAddress(firstAddress);
            customerRepo.Insert(firstCustomer);
            
            // create product repository and add products
            var firstProduct = new Product("C#", "How to learn a song in 30 minutes", 100500);
            var secondProduct = new Product("Coding guru", "How to write code by thought", 9.99);
            var productRepository = new Repository<Product>();
            productRepository.Insert(firstProduct);
            productRepository.Insert(secondProduct);
            
            // create item repository and add items
            var firstItem = new OrderItem(1, productRepository.GetById(1), 2);
            var secondItem = new OrderItem(2, productRepository.GetById(2), 1);
            var itemRepository = new Repository<OrderItem>();
            itemRepository.Insert(firstItem);
            itemRepository.Insert(secondItem);
            
            // create order repository and add orders
            var orderRepository = new Repository<Order>();
            var firstOrder = new Order(1, firstAddress, new List<int> { 1 });
            var secondOrder = new Order(1, firstAddress, new List<int> { 1, 2 });
            orderRepository.Insert(firstOrder);
            orderRepository.Insert(secondOrder);

            orderRepository.Delete(1);

            Console.ReadLine();
        }
    }
}
