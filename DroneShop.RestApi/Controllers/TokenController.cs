using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Droneshop.Core.ApplicationService;
using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;
using Droneshop.Core.Helpers;

namespace DroneShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationHelper _authenticationHelper;

        public TokenController(IUserService userService, IAuthenticationHelper authService)
        {
            _userService = userService;
            _authenticationHelper = authService;
        }


        [HttpPost]
        public IActionResult Login([FromBody]LoginInputModel model)
        {
            var user = _userService.GetAllUsers().FirstOrDefault(u => u.Username == model.Username);

            if (user == null)
            {
                return Unauthorized();
            }

            if (!_authenticationHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            return Ok(new
            {
                username = user.Username,
                token = _authenticationHelper.GenerateToken(user)
            });
        }

    }
}
