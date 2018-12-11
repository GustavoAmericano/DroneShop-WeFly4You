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
    public class DronesController : ControllerBase
    {
        public readonly IDroneService _droneService;

        public DronesController(IDroneService droneService)
        {
            _droneService = droneService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<FilteredList<Drone>> Get([FromQuery]Filter filter)
        {
            try
            {
                return Ok(filter.IncludeOtherEntity ? _droneService.GetAllDronesIncludeManufacturers() : _droneService.GetAllDrones(filter));
            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Drone> Get(int id)
        {
            try
            {
                return Ok(_droneService.ReadById(id));
            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
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
        public ActionResult<Drone> Put(int id, [FromBody] Drone drone)
        {
            try
            {
                drone.Id = id;
                return Ok(_droneService.Update(drone));
            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Drone> Delete(int id)
        {
            try
            {
                return Ok(_droneService.Delete(id));
            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
