using Libreria.Application.Abstractions.Services;
using Libreria.Application.Factories;
using Libreria.Application.Models.Requests;
using Libreria.Application.Models.Responses;
using Libreria.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Web.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;    
        public UserController(IUserService userService)
        {
            _userService = userService; 
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get(int id)
        {
            var result = _userService.Get(id);
            return Ok(ResponseFactory.WithSuccess(new UserResponse(result)));
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            return Ok(ResponseFactory.WithSuccess(new UsersResponse(result)));
        }


        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteUser(int id)
        {
            _userService.Delete(id);
            return Ok(ResponseFactory.WithSuccess());
        }

        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> login(Application.Models.Requests.LoginRequest request)
        //{
        //    var user = _userService.GetUserByName(request.username);
        //    if (user == null || await _userManager.CheckPasswordAsync(user,request.password))
        //    {
        //        Unauthorized();
        //    }
        //    //var token
        //    return Ok();
        //}

        //[HttpGet]
        //[Route("logout")]
        //public IActionResult logout()
        //{
        //    return Ok();
        //}

        //[HttpPost]
        //[Route("signup")]
        //public User signup(CreateUserRequest request)
        //{
        //    return new User();
        //}
    }
}
