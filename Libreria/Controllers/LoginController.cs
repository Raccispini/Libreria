using Libreria.Application.Abstractions.Services;
using Libreria.Application.Models.Dtos;
using Libreria.Application.Models.Requests;
using Libreria.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Libreria.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        public LoginController(IConfiguration configuration,IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;

        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                if (string.IsNullOrEmpty(loginDTO.username) ||
                string.IsNullOrEmpty(loginDTO.password))
                    return BadRequest("Username and/or Password not specified");

                var user = _userService.GetUserByName(loginDTO.username);
                if (user != null && loginDTO.password.Equals(user.password))
                {
                    var secretKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(_configuration["JwtAuth:Key"]));
                    var signinCredentials = new SigningCredentials
                    (secretKey, SecurityAlgorithms.HmacSha256);
                    var jwtSecurityToken = new JwtSecurityToken(
                        issuer: _configuration["JwtAuth:Issuer"],
                        audience: _configuration["JwtAuth:Issuer"],
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: signinCredentials
                    );
                    return Ok(new JwtSecurityTokenHandler().
                    WriteToken(jwtSecurityToken));
                }
            }
            catch(Exception e)
            {
                return BadRequest
                (e.Message);
            }
            return Unauthorized();
        }

        [HttpPut]
        [Route("Signup")]
        public IActionResult registrazione(SignUpRequest request)
        {
            if(_userService.GetUserByName(request.username) == null)
            {
                _userService.Add(request.ToEntity());
                return Ok();
            }
            else
            {
                return BadRequest("L'utente inserito esiste già");
            }
        }
    }
}
