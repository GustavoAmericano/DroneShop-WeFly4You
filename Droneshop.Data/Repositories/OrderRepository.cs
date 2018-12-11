using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Droneshop.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly DroneShopContext _ctx;

        public OrderRepository(DroneShopContext ctx)
        {
            _ctx = ctx;
        }


        public Order CreateOrder(Order order)
        {
            _ctx.Attach(order).State = EntityState.Added;
            _ctx.SaveChanges();
            return order;
        }

        public Order DeleteOrder(int id)
        {
            var removedOrder = _ctx.Remove(new Order { Id = id }).Entity;
            _ctx.SaveChanges();
            return removedOrder;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _ctx.Orders.Include(o => o.Customer).Include(o => o.OrderLines).ThenInclude(ol => ol.Drone);
        }

        public Order ReadOrderById(int id)
        {
            return _ctx.Orders.Include(o => o.Customer).Include(o => o.OrderLines).ThenInclude(ol => ol.Drone).FirstOrDefault(o => o.Id == id);

        }

        public Order UpdateOrder(Order order)
        {
            var newOrderLines = new List<OrderLine>(order.OrderLines);
            _ctx.Attach(order).State = EntityState.Modified;
            _ctx.OrderLines.RemoveRange(_ctx.OrderLines.Where(ol => ol.OrderId == order.Id));

            foreach (var ol in newOrderLines)
            {
                _ctx.Entry(ol).State = EntityState.Added;
            }

            _ctx.Entry(order).Reference(o => o.Customer).IsModified = true;
            _ctx.SaveChanges();
            return order;

        }
    }
}
