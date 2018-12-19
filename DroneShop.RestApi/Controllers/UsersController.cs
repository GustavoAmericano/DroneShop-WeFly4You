using System;
using System.Collections.Generic;
using Droneshop.Core.ApplicationService;
using Droneshop.Core.Entity;
using Droneshop.Core.Helpers;
using Microsoft.AspNetCore.Authorization;
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


        [HttpGet("{username}")]
        [Authorize]
        public ActionResult<Customer> Get(string username)
        {
            try
            {
                return Ok(_userService.GetUsersCustomerInfo(username));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<User> Post([FromBody] LoginInputModel model)
        {
            try {
                _authenticationHelper.CreatePasswordHash(model.Password, out var passwordHash, out var passwordSalt);              
                var user = new User() {
                    Username = model.Username,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
              
                return Ok(_userService.CreateUser(user));
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
             
    }
}