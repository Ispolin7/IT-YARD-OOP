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
    public class OrderServiceTests
    {
        public OrderService Service { get; set; }

        public Repository<Customer> TestRepositoryCustomer { get; set; }
        public Repository<Order> TestRepositoryOrder { get; set; }
        public Repository<OrderItem> TestRepositoryOrderItem { get; set; }

        public Customer TestCustomer { get; set; }
        public Order TestOrder { get; set; }
        public OrderItem TestOrderItem { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            var customerStub = new CustomerStubRepository();
            var orderStub = new OrderStubRepository();
            var orderItemStub = new OrderItemStubRepository();

            this.TestRepositoryCustomer = customerStub.Customers;
            this.TestRepositoryOrder = orderStub.Orders;
            this.TestRepositoryOrderItem = orderItemStub.OrderItems;

            this.TestCustomer = customerStub.TestCustomer;
            this.TestOrder = orderStub.TestOrder;
            this.TestOrderItem = orderItemStub.TestOrderItem;

            Service = new OrderService(TestRepositoryOrder, TestRepositoryCustomer, TestRepositoryOrderItem);
        }

        

        [TestMethod]
        public void AddNewOrder_Expected4OrderInRepository()
        {
            TestOrder.Id = Guid.NewGuid();
            Service.AddNewOrder(TestOrder);
            var customersCount = Service.GetAllOrders().Count();
            Assert.IsTrue(customersCount == 4, $"Emount of elements - {customersCount}, expected - 4");
        }

        [TestMethod]
        public void GetAllOrders_ExpectedCount3()
        {
            var orders = Service.GetAllOrders();
            var count = orders.Count();
            Assert.IsTrue(count == 3, $"Emount of elements - {count},expected - 3");
        }

        [TestMethod]
        public void GetAllOrdersWithItems_Expected2ItemsInFirstOrder()
        {
            var orders = Service.GetAllOrdersWithItems();
            var firstOrderItems = orders.First().Items.Count();
            Assert.IsTrue(firstOrderItems == 2, $"Emount of elements - {firstOrderItems},expected - 2");
        }

        [TestMethod]
        public void GetOrder_ExpectedTestOrderCustomerId()
        {
            var order = Service.GetOrder(TestOrder.Id);
            var customerId = order.CustomerId;
            Assert.IsTrue(customerId == TestOrder.CustomerId, $"Current id - {customerId}, but expected - {TestOrder.CustomerId}");
        }

        [TestMethod]
        public void GetOrderWithItems_Expected2ItemsInTestOrder()
        {
            var order = Service.GetOrderWithItems(TestOrder.Id);
            var itemsCount = order.Items.Count();
            Assert.IsTrue(itemsCount == 2, $"Emount of elements - {itemsCount}, expected - 2");
        }

        [TestMethod]
        public void Remove_StateUnderTest_Expected2Elements()
        {
            Service.Remove(TestOrder.Id);
            var ordersCount = Service.GetAllOrders().Count();
            Assert.IsTrue(ordersCount == 2, $"Emount of elements - {ordersCount}, expected - 2");
        }

        [TestMethod]
        public void Update_StateUnderTest_ExpectedTrueInFieldIsDeleted()
        {
            TestOrder.IsDeleted = true;
            var result = Service.Update(TestOrder);
            var ordersCount = Service.GetAllOrders().Count();
            Assert.IsTrue(ordersCount == 2, $"Emount of elements - {ordersCount}, expected - 2");
        }
    }
}
