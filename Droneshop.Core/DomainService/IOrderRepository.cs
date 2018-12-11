using Droneshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Droneshop.Core.DomainService
{
    public interface IOrderRepository
    {
        Order CreateOrder(Order order);
        Order ReadOrderById(int id);
        IEnumerable<Order> GetAllOrders();
        Order UpdateOrder(Order order);
        Order DeleteOrder(int id);
    }
}
