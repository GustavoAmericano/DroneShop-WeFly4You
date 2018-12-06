using Droneshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Droneshop.Core.ApplicationService
{
    public interface IOrderService
    {
        Order CreateOrder(Order order);
        Order ReadOrderById(int id);
        List<Order> GetAllOrders();
        Order UpdateOrder(Order order);
        Order DeleteOrder(int id);
    }
}
