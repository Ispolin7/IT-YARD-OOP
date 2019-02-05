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
            var secondAddress = new Address(2, "Street", "777", "Poltava", "DC Columbia", "000", "Tobago");
            var addressRepo = new CheatingRepository<Address>();
            addressRepo.Insert(firstAddress);
            addressRepo.Insert(secondAddress);

            // create user repository and add users
            var firstUser = new User("Starter", "password");
            var secondUser = new User("Mega", "Hacker!");
            var userRepo = new CheatingRepository<User>();
            userRepo.Insert(firstUser);
            userRepo.Insert(secondUser);

            // create customer repository and add customers
            var customerRepo = new CheatingRepository<Customer>();            
            var firstCustomer = new Customer("Rich", "Buyer", "buyer@mail.com", 1, 1);
            var secondCustomer = new Customer("Poor", "Gaper", "gaper@mail.com", 2, 2);
            var thirdCustomer = new Customer("Stray", "Guy", "stray@mail.com", 1, 2);
            var fourthCustomer = new Customer("Owner", "Store", "owner@mail.com", 2, 1);

            firstCustomer.AddAddress(firstAddress);
            customerRepo.Insert(firstCustomer);
            customerRepo.Insert(secondCustomer);
            customerRepo.Insert(thirdCustomer);
            customerRepo.Insert(fourthCustomer);

            // create product repository and add products
            var firstProduct = new Product("C#", "How to learn a song in 30 minutes", 100500);
            var secondProduct = new Product("Coding guru", "How to write code by thought", 9.99);
            var productRepository = new CheatingRepository<Product>();
            productRepository.Insert(firstProduct);
            productRepository.Insert(secondProduct);

            // create order repository and add orders
            var orderRepository = new CheatingRepository<Order>();
            var firstOrder = new Order(firstCustomer.Id, firstAddress);
            var secondOrder = new Order(secondCustomer.Id, secondAddress);
            var thirddOrder = new Order(thirdCustomer.Id, firstAddress);
            var fourthdOrder = new Order(fourthCustomer.Id, secondAddress);
            orderRepository.Insert(firstOrder);
            orderRepository.Insert(secondOrder);
            orderRepository.Insert(thirddOrder);
            orderRepository.Insert(fourthdOrder);

            //create item repository and add items
            var firstItem = new OrderItem(firstProduct, 1, firstOrder.Id);
            var secondItem = new OrderItem(secondProduct, 2, secondOrder.Id);
            var itemRepository = new CheatingRepository<OrderItem>();
            itemRepository.Insert(firstItem);
            itemRepository.Insert(secondItem);

            // delete two customers
            customerRepo.Delete(thirdCustomer.Id);
            customerRepo.Delete(fourthCustomer.Id);

            var allCustomers = customerRepo.All();
        
            foreach(var customer in allCustomers)
            {
                customer.DisplayEntityInfo();
                Console.WriteLine("Orders:");
                if(customer.Orders != null)
                {
                    foreach (var order in customer.Orders)
                    {
                        order.DisplayEntityInfo();
                        Console.WriteLine("Order Items:");
                        if(order.Items != null)
                        {
                            foreach (OrderItem item in order.Items)
                            {
                                item.DisplayEntityInfo();
                                Console.WriteLine("Products:");
                                if(item.Products != null)
                                {
                                    foreach (Product product in item.Products)
                                    {
                                        product.DisplayEntityInfo();
                                    }
                                }
                                
                            }
                        }
                        
                    }
                }
                
                Console.WriteLine(new string('=',30));
            }

            Console.ReadLine();
        }
    }
}
