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

            ValidateData(order);
            return _orderRepo.CreateOrder(order);
        }

        public Order DeleteOrder(int id)
        {

            if (id < 1)
            {
                throw new ArgumentException("The entered id has to be atleast 1");
            }
            
            return _orderRepo.DeleteOrder(id);
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepo.GetAllOrders().ToList();
        }

        public Order ReadOrderById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("The entered id has to be atleast 1");
            }

            var orderFound = _orderRepo.ReadOrderById(id);

            if (orderFound == null)
            {
                throw new ArgumentException("Couldn't find any orders with the entered id");
            }
            
            return _orderRepo.ReadOrderById(id);
        }

        public Order UpdateOrder(Order order)
        {

            ValidateData(order);
            return _orderRepo.UpdateOrder(order);
        }

            
        

        private void ValidateData(Order order)
        {


            if (order.OrderDate == null)
            {
                throw new ArgumentException("OrderDate Cannot Be Null or Empty");
            }

            if (order.Customer == null)
            {
                throw new ArgumentException("Customer Cannot Be Null or Empty");
            }

            if (order.OrderLines == null)
            {
                throw new ArgumentException("OrderLine Cannot Be Null or Empty");
            }

           
        }

    }
}
