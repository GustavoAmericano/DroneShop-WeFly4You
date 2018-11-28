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
    public class DroneController : ControllerBase
    {
        public readonly IDroneService _droneService;

        public DroneController(IDroneService droneService)
        {
            _droneService = droneService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Drone> Post([FromBody] Drone drone)
        {
            try
            {
                return Ok(_droneService.Create(drone));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
