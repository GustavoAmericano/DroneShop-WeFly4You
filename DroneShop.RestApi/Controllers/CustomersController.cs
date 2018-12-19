using System;
using System.Collections.Generic;
using Droneshop.Core.ApplicationService;
using Droneshop.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DroneShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            try
            {
                return Ok(_customerService.ReadAllCustomers());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // GET api/values/1
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            try
            {
                return Ok(_customerService.ReadCustomerById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
        
        // POST api/values
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            try
            {
                return _customerService.CreateCustomer(customer);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Customer> Put(int id, [FromBody] Customer customer)
        {
            
            try
            {
                customer.Id = id;
                return Ok(_customerService.UpdateCustomer(customer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<Customer> Delete(int id)
        {
            try
            {
                return Ok(_customerService.DeleteCustomer(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}