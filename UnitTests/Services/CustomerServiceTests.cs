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

        [TestInitialize]
        public void TestInitialize()
        {
            var TestRepository = new StubRepository();
            TestRepositoryCustomer = TestRepository.ÑustomersRepositoryInitialization();
            TestRepositoryOrder = TestRepository.OrdersRepositoryInitialization();
            Service = new CustomerService(TestRepositoryCustomer, TestRepositoryOrder);
        }

        [TestMethod]
        public void GetAllCustomers_GetCustomersFromDB_ExpectedCount3()
        {
            var customers = Service.GetAllCustomers();
            var count = customers.Count();
            Assert.IsTrue(count == 3, $"Emount of elements - {count},expected - 3");
        }

        [TestMethod]
        public void GetAllCustomersWithProducts_AddProductsToCustomers_Expected2Orders()
        {
            var customers = Service.GetAllCustomersWithProducts();
            var firstCustomerOrdersCount = customers.First().Orders.Count();
            Assert.IsTrue(firstCustomerOrdersCount == 2, $"Emount of elements - {firstCustomerOrdersCount},expected - 2");
        }

        [TestMethod]
        public void AddNewCustomer_InsertNewItemInRepository_Expected4Customers()
        {
            var testCustomer = new Customer()
            {
                Id = Guid.Parse("edb050f5-ca3b-4381-a4ba-7b57ebeb1083"),
                FirstName = "Test",
                LastName = "Test",
                Email = "Test@mail.com",
                Gender = 1
            };
            Service.AddNewCustomer(testCustomer);
            var customersCount = Service.GetAllCustomers().Count();
            Assert.IsTrue(customersCount == 4, $"Emount of elements - {customersCount}, expected - 4");
        }

        [TestMethod]
        public void GetCustomer_GetItemFromRepository_ExpectedNameGaper()
        {
            var customer = Service.GetCustomer(Guid.Parse("edb050f5-ca3b-4381-a4ba-7b57ebeb108f"));
            var customerName = customer.LastName;
            Assert.IsTrue(customerName == "Gaper", $"Current Name - {customerName}, but expected - Gaper");
        }

        [TestMethod]
        public void GetCustomerWithProducts_GetItemFromRepository_ExpectedCountOfproducts2()
        {
            var customer = Service.GetCustomerWithProducts(Guid.Parse("edb050f5-ca3b-4381-a4ba-7b57ebeb108f"));
            var productsCount = customer.Orders.Count();
            Assert.IsTrue(productsCount == 2, $"Emount of elements - {productsCount}, expected - 2");
        }

        [TestMethod]
        public void Update_UpdateItem_ExpectedSuccess()
        {
            var testCustomer = new Customer()
            {
                Id = Guid.Parse("edb050f5-ca3b-4381-a4ba-7b57ebeb108f"),
                FirstName = "Test",
                LastName = "Test",
                Email = "Test@mail.com",
                Gender = 1
            };
            var result = Service.Update(testCustomer);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Remove_DeleteItem_Expected2Customers()
        {
            Service.Remove(Guid.Parse("edb050f5-ca3b-4381-a4ba-7b57ebeb108f"));
            var customerCount = Service.GetAllCustomers().Count();
            Assert.IsTrue(customerCount == 2, $"Emount of elements - {customerCount}, expected - 2");
        }
    }
}
