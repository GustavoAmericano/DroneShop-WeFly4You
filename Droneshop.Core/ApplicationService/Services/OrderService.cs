using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;

namespace Droneshop.Core.ApplicationService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;

        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public Order CreateOrder(Order order)
        {
            return _orderRepo.CreateOrder(order);
        }

        public Order DeleteOrder(int id)
        {
            return _orderRepo.DeleteOrder(id);
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepo.GetAllOrders().ToList();
        }

        public Order ReadOrderById(int id)
        {
            return _orderRepo.ReadOrderById(id);
        }

        public Order UpdateOrder(Order order)
        {
            return _orderRepo.UpdateOrder(order);
        }
    }
}
