using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Droneshop.Core.ApplicationService;
using Droneshop.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DroneShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturersController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Manufacturer>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(filter.IncludeOtherEntity ? _manufacturerService.GetAllManufacturersIncludeDrones() : _manufacturerService.GetAllManufacturers(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // GET api/values/1
        [HttpGet("{id}")]
        public ActionResult<Manufacturer> Get(int id)
        {
            try
            {
                return Ok(_manufacturerService.ReadById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
        
        // POST api/values
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult<Manufacturer> Post([FromBody] Manufacturer manufacturer)
        {
            try
            {
                return _manufacturerService.Create(manufacturer);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        // PUT api/values/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<Manufacturer> Put(int id, [FromBody] Manufacturer manufacturer)
        {
            
            try
            {
                manufacturer.Id = id;
                return Ok(_manufacturerService.Update(manufacturer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<Manufacturer> Delete(int id)
        {
            try
            {
                return Ok(_manufacturerService.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}