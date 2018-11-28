using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Droneshop.Core.ApplicationService;
using Droneshop.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DroneShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Manufacturer>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_manufacturerService.GetAllManufacturers(filter));
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
        
        
    }
}