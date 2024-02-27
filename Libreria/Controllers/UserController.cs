using Libreria.Application.Abstractions.Services;
using Libreria.Application.Models.Requests;
using Libreria.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService; 
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get(int id)
        {
            return Ok(_userService.Get(id));
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpPut]
        [Route("New")]
        public IActionResult NewUser(CreateUserRequest request)
        {
            var user = request.ToEntity();
            _userService.Add(user);
            return Ok(user);
        }
        [HttpPost]
        [Route("Edit")]
        public IActionResult EditUser(CreateUserRequest request)
        {
            var user = request.ToEntity();
            _userService.Update(user);
            return Ok(user);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteUser(int id)
        {
            _userService.Delete(id);
            return Ok();
        }

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
