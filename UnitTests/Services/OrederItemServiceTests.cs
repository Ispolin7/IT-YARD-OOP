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
    public class OrederItemServiceTests
    {
        public OrderItemService Service { get; set; }

        public Repository<Product> TestRepositoryProduct { get; set; }
        public Repository<Order> TestRepositoryOrder { get; set; }
        public Repository<OrderItem> TestRepositoryOrderItem { get; set; }

        public Product TestProduct { get; set; }
        public Order TestOrder { get; set; }
        public OrderItem TestOrderItem { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            var productStub = new ProductStubRepository();
            var orderStub = new OrderStubRepository();
            var orderItemStub = new OrderItemStubRepository();

            this.TestRepositoryProduct = productStub.Products;
            this.TestRepositoryOrder = orderStub.Orders;
            this.TestRepositoryOrderItem = orderItemStub.OrderItems;

            this.TestProduct = productStub.TestProduct;
            this.TestOrder = orderStub.TestOrder;
            this.TestOrderItem = orderItemStub.TestOrderItem;

            Service = new OrderItemService(TestRepositoryOrderItem, TestRepositoryProduct, TestRepositoryOrder);
        }


        [TestMethod]
        public void AddNewItem_Expected3ElementsInRepository()
        {
            TestOrderItem.Id = Guid.NewGuid();
            Service.AddNewItem(TestOrderItem);
            var itemCount = Service.GetAllItems().Count();
            Assert.IsTrue(itemCount == 3, $"Emount of elements - {itemCount}, expected - 3");
        }

        [TestMethod]
        public void GetAllItems_Expected2ElementsInRepository()
        {
            var items = Service.GetAllItems();
            var count = items.Count();
            Assert.IsTrue(count == 2, $"Emount of elements - {count},expected - 2");
        }

        [TestMethod]
        public void GetAllItemsWithRelations_ExpectedNotNullValueInProduct()
        {
            var items = Service.GetAllItemsWithRelations();
            var  product = items.First().Product;
            Assert.IsTrue(!string.IsNullOrWhiteSpace(product.Name));
        }

        [TestMethod]
        public void GetItem_ExpectedIntInProperty()
        {
            var item = Service.GetItem(TestOrderItem.Id);
            var quantity = item.Quantity;
            Assert.IsTrue(quantity > 0, $"Current quantity - {quantity}");
        }

        [TestMethod]
        public void GetItemWithRelations_ExpectedNotNullValueInProduct()
        {
            var item = Service.GetItemWithRelations(TestOrderItem.Id);
            var product = item.Product;
            Assert.IsTrue(!string.IsNullOrWhiteSpace(product.Name));
        }

        [TestMethod]
        public void Remove_Expected1ElementInRepository()
        {
            Service.Remove(TestOrderItem.Id);
            var itemsCount = Service.GetAllItems().Count();
            Assert.IsTrue(itemsCount == 1, $"Emount of elements - {itemsCount}, expected - 1");
        }

        [TestMethod]
        public void Update_Expected1ElementInRepository()
        {
            TestOrderItem.IsDeleted = true;
            var result = Service.Update(TestOrderItem);
            var itemsCount = Service.GetAllItems().Count();
            Assert.IsTrue(itemsCount == 1, $"Emount of elements - {itemsCount}, expected - 1");
        }
    }
}
