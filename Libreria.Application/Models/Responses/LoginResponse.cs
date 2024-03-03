using Libreria.Application.Models.Dtos;

namespace Libreria.Application.Models.Responses
{
    public class LoginResponse 
    {
        public string token { get; set; }= String.Empty;
        public LoginResponse(string token)
        {
            this.token = token;
        }
        
        
    }
}
