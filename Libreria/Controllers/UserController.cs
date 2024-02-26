using Libreria.Application.Models.Requests;
using Libreria.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController:ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public IActionResult login()
        {
            return Ok();
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult logout()
        {
            return Ok();
        }

        [HttpPost]
        [Route("signup")]
        public User signup(CreateUserRequest request)
        {
            return new User();
        }
    }
}
