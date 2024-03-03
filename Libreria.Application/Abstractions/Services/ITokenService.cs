using Libreria.Application.Models.Requests;

namespace Libreria.Application.Abstractions.Services
{
    public interface ITokenService
    {
        string GetToken(LoginRequest request);
    }
}
