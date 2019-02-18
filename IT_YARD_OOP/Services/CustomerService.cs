using IT_YARD.Models;
using IT_YARD.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IT_YARD.Interfaces;
using IT_YARD.Common;

namespace IT_YARD.Services
{
    public class CustomerService : ICustomerService
    {
        /// <summary>
        /// Customer and order repositories
        /// </summary>
        private IRepository<Customer> Customers { get; }
        private IRepository<Order> Orders { get; }

        /// <summary>
        /// service constructor
        /// </summary>
        /// <param name="customerRepository"></param>
        /// <param name="orderRepository"></param>
        public CustomerService(IRepository<Customer> customerRepository, IRepository<Order> orderRepository)
        {
            this.Customers = customerRepository;
            this.Orders = orderRepository;
        }

        /// <summary>
        /// Get Customers collection
        /// </summary>
        /// <returns>customers collection</returns>
        public IEnumerable<Customer> GetAllCustomers()
        {
            return this.Customers.All().Where(c => c.IsDeleted == false);
        }

        /// <summary>
        /// Add products to customer collection
        /// </summary>
        /// <returns>collection with orders</returns>
        public IEnumerable<Models.Customer> GetAllCustomersWithProducts()
        {
            var customersCollection = this.GetAllCustomers();
            return customersCollection.Select(c => new Models.Customer(c, this.Orders.All().Where(o => (o.CustomerId == c.Id) && (o.IsDeleted == false))));
        }

        /// <summary>
        /// Add new Customer to repository
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool AddNewCustomer(Customer customer)
        {
            if(customer.Validate())
            {
                return Customers.Insert(customer);               
            }
            Logger.LogError($"Customer not added, validation error");
            return false;
        }

        /// <summary>
        /// Get Customer information
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Customer or exception</returns>
        public Customer GetCustomer(Guid id)
        {
            if(Customers.InRepository(id))
            {
                return Customers.GetById(id);
            }
            throw new KeyNotFoundException("Customer not found");
        }

        /// <summary>
        /// Add products to customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Customer or exception</returns>
        public Models.Customer GetCustomerWithProducts(Guid id)
        {
            var customer = this.GetCustomer(id);
            var orders = this.Orders.All().Where(o => o.CustomerId == customer.Id);
            return new Models.Customer(customer, orders);
        }

        /// <summary>
        /// Update customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>bool success</returns>
        public bool Update(Customer customer)
        {
            if(customer.Validate() && Customers.InRepository(customer.Id))
            {
                return Customers.Update(customer);
            }
            throw new KeyNotFoundException("Customer not found");
        }

        /// <summary>
        /// Soft Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool success</returns>
        public bool Remove(Guid id)
        {
            if(Customers.InRepository(id))
            {
                var customer = Customers.GetById(id);
                customer.IsDeleted = true;
                return Customers.Update(customer);
            }
            throw new KeyNotFoundException("Customer not found");
        }
    }
}
