using IT_YARD.Common;
using IT_YARD.Interfaces;
using IT_YARD.Models;
using IT_YARD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IT_YARD.Services
{
    public class OrderItemService : IOrederItemService
    {
        private IRepository<OrderItem> Items { get; }
        private IRepository<Product> Products { get; }
        private IRepository<Order> Orders { get; }

        public OrderItemService(
            IRepository<OrderItem> items,
            IRepository<Product> products,
            IRepository<Order> orders)
        {
            this.Items = items;
            this.Products = products;
            this.Orders = orders;
        }

        public bool AddNewItem(OrderItem item)
        {
            if (item.Validate() && Products.InRepository(item.ProductId) && Orders.InRepository(item.OrderId))
            {
                return Items.Insert(item);
            }
            return false;
        }

        public IEnumerable<OrderItem> GetAllItems()
        {
            return this.Items.All().Where(i => i.IsDeleted == false);
        }

        public IEnumerable<Models.OrderItem> GetAllItemsWithRelations()
        {
            var itemCollection = this.GetAllItems();
            return itemCollection.Select(i => new Models.OrderItem(
                i, 
                this.Products.All().Where(p => (p.Id == i.ProductId) && (p.IsDeleted == false)).First(),
                this.Orders.All().Where(o => (o.Id == i.OrderId) && (o.IsDeleted == false)).First() 
            ));
        }

        public OrderItem GetItem(Guid id)
        {
            if (Items.InRepository(id))
            {
                return Items.GetById(id);
            }
            throw new KeyNotFoundException("OrderItem not found");
        }

        public Models.OrderItem GetItemWithRelations(Guid id)
        {
            var item = this.GetItem(id);
            var product = this.Products.All().Where(p => (p.Id == item.ProductId) && (p.IsDeleted == false)).First();
            var order = this.Orders.All().Where(o => (o.Id == item.OrderId) && (o.IsDeleted == false)).First();
            return new Models.OrderItem(item, product, order);
        }

        public bool Remove(Guid id)
        {
            if (Items.InRepository(id))
            {
                var item = Items.GetById(id);
                item.IsDeleted = true;
                return Items.Update(item);
            }
            throw new KeyNotFoundException("OrderItem not found");
        }

        public bool Update(OrderItem item)
        {
            if (
                item.Validate() &&
                Products.InRepository(item.ProductId) &&
                Orders.InRepository(item.OrderId) &&
                Items.InRepository(item.Id))
            {
                return Items.Update(item);
            }
            throw new KeyNotFoundException("Incorrect data");
        }
    }
}
