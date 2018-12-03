using System;
using System.Collections.Generic;
using Droneshop.Core.ApplicationService;
using Droneshop.Core.Entity;
using Droneshop.Core.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DroneShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationHelper _authenticationHelper;

        public UsersController(IUserService userService, IAuthenticationHelper authenticationHelper)
        {
            _userService = userService;
            _authenticationHelper = authenticationHelper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            try
            {
                return Ok(_userService.GetAllUsers());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            try
            {
                return Ok(_userService.ReadUserById(id));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<User> Post([FromBody] LoginInputModel model)
        {
            try
            {
                _authenticationHelper.CreatePasswordHash(model.Password, out var passwordHash, out var passwordSalt);
                
                var user = new User()
                {
                    Username = model.Username,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
                
                return Ok(_userService.CreateUser(user));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] LoginInputModel model)
        {
            try
            {
                _authenticationHelper.CreatePasswordHash(model.Password, out var passwordHash, out var passwordSalt);
                
                var user = new User()
                {
                    Id = id,
                    Username = model.Username,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
                
                
                user.Id = id;
                return Ok(_userService.UpdateUser(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            try
            {
                return Ok(_userService.DeleteUser(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}