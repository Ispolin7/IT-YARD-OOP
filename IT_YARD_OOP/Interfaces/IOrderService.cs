using IT_YARD.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IT_YARD.Interfaces
{
    interface IOrderService
    {
        IEnumerable<Order> GetAllOrders();
        IEnumerable<Services.Models.Order> GetAllOrdersWithItems();
        bool AddNewOrder(Order order);
        Order GetOrder(Guid id);
        Services.Models.Order GetOrderWithItems(Guid id);
        bool Update(Order order);
        bool Remove(Guid id);
    }
}
