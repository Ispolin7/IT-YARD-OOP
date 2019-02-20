using IT_YARD.Models;
using IT_YARD.Repositories;
using IT_YARD.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using UnitTests.Stubs;

namespace UnitTests.Services
{
    [TestClass]
    public class CustomerServiceTests
    {
        public CustomerService Service { get; set; }

        public Repository<Customer> TestRepositoryCustomer { get; set; }       
        public Repository<Order> TestRepositoryOrder { get; set; }

        public Customer TestCustomer { get; set; }
        public Order TestOrder { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            var customerStub = new CustomerStubRepository();
            var orderStub = new OrderStubRepository();

            this.TestRepositoryCustomer = customerStub.Customers;
            this.TestRepositoryOrder = orderStub.Orders;

            this.TestCustomer = customerStub.TestCustomer;
            this.TestOrder = orderStub.TestOrder;

            Service = new CustomerService(TestRepositoryCustomer, TestRepositoryOrder);
        }

        [TestMethod]
        public void GetAllCustomers_ExpectedCount3()
        {
            var customers = Service.GetAllCustomers();
            var count = customers.Count();
            Assert.IsTrue(count == 3, $"Emount of elements - {count},expected - 3");
        }

        [TestMethod]
        public void GetAllCustomersWithProducts_Expected2Orders()
        {
            var customers = Service.GetAllCustomersWithProducts();
            var firstCustomerOrdersCount = customers.First().Orders.Count();
            Assert.IsTrue(firstCustomerOrdersCount == 2, $"Emount of elements - {firstCustomerOrdersCount},expected - 2");
        }

        [TestMethod]
        public void AddNewCustomer_Expected4Customers()
        {
            TestCustomer.Id = Guid.NewGuid();
            Service.AddNewCustomer(TestCustomer);
            var customersCount = Service.GetAllCustomers().Count();
            Assert.IsTrue(customersCount == 4, $"Emount of elements - {customersCount}, expected - 4");
        }

        [TestMethod]
        public void GetCustomer_ExpectedNameGaper()
        {
            var customer = Service.GetCustomer(TestCustomer.Id);
            var customerName = customer.LastName;
            Assert.IsTrue(customerName == TestCustomer.LastName, $"Current Name - {customerName}, but expected - {TestCustomer.LastName}");
        }

        [TestMethod]
        public void GetCustomerWithProducts_ExpectedCountOfproducts2()
        {
            var customer = Service.GetCustomerWithProducts(TestCustomer.Id);
            var productsCount = customer.Orders.Count();
            Assert.IsTrue(productsCount == 2, $"Emount of elements - {productsCount}, expected - 2");
        }

        [TestMethod]
        public void Update_ExpectedSuccess()
        {
            TestCustomer.LastName = "Test Update";
            var result = Service.Update(TestCustomer);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Remove_Expected2Customers()
        {
            Service.Remove(TestCustomer.Id);
            var customerCount = Service.GetAllCustomers().Count();
            Assert.IsTrue(customerCount == 2, $"Emount of elements - {customerCount}, expected - 2");
        }
    }
}
