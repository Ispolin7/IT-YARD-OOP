using IT_YARD.Common;
using IT_YARD.Models;
using IT_YARD.Interfaces;
using IT_YARD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IT_YARD.Services
{
    public class OrderService : IOrderService
    {
        private IRepository<Customer> Customers { get; }
        private IRepository<Order> Orders { get; }
        private IRepository<OrderItem> Items { get; }

        public OrderService(
            IRepository<Order> orders,
            IRepository<Customer> customers,
            IRepository<OrderItem> items
            )
        {
            this.Customers = customers;
            this.Orders = orders;
            this.Items = items;
        }

        public bool AddNewOrder(Order order)
        {
            if (order.Validate() && Customers.InRepository(order.CustomerId))
            {
                return Orders.Insert(order);
            }
            Logger.LogError($"Order not added");
            return false;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return this.Orders.All().Where(o => o.IsDeleted == false);
        }

        public IEnumerable<Models.Order> GetAllOrdersWithItems()
        {
            var orderCollection = this.GetAllOrders();
            return orderCollection.Select(o => new Models.Order(o, this.Items.All().Where(i => (i.OrderId == o.Id) && (i.IsDeleted == false))));
        }

        public Order GetOrder(Guid id)
        {
            if (Orders.InRepository(id))
            {
                return Orders.GetById(id);
            }
            throw new KeyNotFoundException("Order not found");
        }

        public Models.Order GetOrderWithItems(Guid id)
        {
            var order = this.GetOrder(id);
            var items = this.Items.All().Where(i => i.OrderId == order.Id);
            return new Models.Order(order, items);
        }

        public bool Remove(Guid id)
        {
            if (Orders.InRepository(id))
            {
                var order = Orders.GetById(id);
                order.IsDeleted = true;
                return Orders.Update(order);
            }
            throw new KeyNotFoundException("Order not found");
        }

        public bool Update(Order order)
        {
            if (order.Validate() && Orders.InRepository(order.Id) && Customers.InRepository(order.CustomerId))
            {
                return Orders.Update(order);
            }
            throw new KeyNotFoundException("Order not found");
        }
    }
}
