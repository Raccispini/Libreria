using Libreria.Application.Abstractions.Services;
using Libreria.Application.Models.Requests;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Libreria.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetToken(LoginRequest request)
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
            return new JwtSecurityTokenHandler().
                    WriteToken(jwtSecurityToken);
        }
    }
}
