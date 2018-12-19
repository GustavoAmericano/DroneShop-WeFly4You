using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Droneshop.Core.ApplicationService;
using Droneshop.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DroneShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Orders
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Order>> Get()
        {
            try
            {
                return Ok(_orderService.GetAllOrders());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            try
            {
                return Ok(_orderService.ReadOrderById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Orders
        [HttpPost]
        [Authorize]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            try
            {
                return Ok(_orderService.CreateOrder(order));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<Order> Put(int id, [FromBody] Order order)
        {
            try
            {
                return Ok(_orderService.UpdateOrder(order));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<Order> Delete(int id)
        {
            try
            {
                return Ok(_orderService.DeleteOrder(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
