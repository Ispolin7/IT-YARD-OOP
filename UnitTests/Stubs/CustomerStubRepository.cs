using IT_YARD.Models;
using IT_YARD.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Stubs
{
    public class CustomerStubRepository
    {
        public Repository<Customer> Customers { get; set; }
        public Customer TestCustomer { get; set; }

        public CustomerStubRepository()
        {
            this.Customers = new Repository<Customer>();
            this.TestCustomer = new Customer
            {
                Id = Guid.Parse("edb050f5-ca3b-4381-a4ba-7b57ebeb108f"),
                FirstName = "Poor",
                LastName = "Gaper",
                Email = "gaper@mail.com",
                Gender = 1
            };

            this.Customers.Items.Add(TestCustomer.Id, TestCustomer);
            this.Customers.Items.Add(
                Guid.Parse("02aaa926-2d33-4935-9e55-478d4b10d988"),
                new Customer
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
                new Customer
                {
                    Id = Guid.Parse("02aaa926-2d33-4935-9e55-478d4b10d777"),
                    FirstName = "Stray",
                    LastName = "Guy",
                    Email = "stray@mail.com",
                    Gender = 1
                }
            );
        }
    }
}
