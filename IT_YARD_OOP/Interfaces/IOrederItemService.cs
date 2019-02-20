using IT_YARD.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IT_YARD.Interfaces
{
    interface IOrederItemService
    {
        IEnumerable<OrderItem> GetAllItems();
        IEnumerable<Services.Models.OrderItem> GetAllItemsWithRelations();
        bool AddNewItem(OrderItem item);
        OrderItem GetItem(Guid id);
        Services.Models.OrderItem GetItemWithRelations(Guid id);
        bool Update(OrderItem item);
        bool Remove(Guid id);
    }
}
