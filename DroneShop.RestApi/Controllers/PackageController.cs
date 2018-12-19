using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Droneshop.Core.ApplicationService.Services;
using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DroneShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PackageController : ControllerBase
    {
        private readonly IPackageService _PackService;

        public PackageController(IPackageService Packservice)
        {
            _PackService = Packservice;

        }
        // Get all packages
        [HttpGet]
        public ActionResult<IEnumerable<Package>> Get()
        {
            try
            {
                return Ok(_PackService.GetAllPackages());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
        // Get package by id
        [HttpGet("{id}")]
        public ActionResult<Package> Get(int id)
        {
            try
            {
                return Ok(_PackService.ReadById(id));
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // Create package
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult<Package> Post(Package package)
        {
            try
            {
                return Ok(_PackService.Create(package));
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // Update package
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<Package> Put(int id, [FromBody] Package package)
        {
            try
            {
                package.Id = id;
                return Ok(_PackService.Update(package));
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public ActionResult <Package> Delete(int id)
        {
            try
            {
                return Ok(_PackService.Delete(id));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
