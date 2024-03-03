using Libreria.Application.Abstractions.Services;
using Libreria.Application.Factories;
using Libreria.Application.Models.Requests;
using Libreria.Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;


namespace Libreria.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public LoginController(IConfiguration configuration,IUserService userService,ITokenService tokenService)
        {
            _configuration = configuration;
            _userService = userService;
            _tokenService = tokenService;

        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginRequest request)
        {
                var user = _userService.GetUserByName(request.username);
                if (user != null && request.password.Equals(user.password))
                {
                    return Ok(ResponseFactory.WithSuccess(new LoginResponse(_tokenService.GetToken(request))));

                }

            throw new Exception("Email o password non valide");
            //return BadRequest(ResponseFactory.WithErrors("Unautorized"));
        }

        [HttpPost]
        [Route("Signup")]
        public IActionResult registrazione(SignUpRequest request)
        {
            if(_userService.GetUserByName(request.username) == null)
            {
                _userService.Add(request.ToEntity());
                return Ok(ResponseFactory.WithSuccess());
            }
            else
            {
                throw new Exception("L'username inserito esiste già");
            }
        }
    }
}
