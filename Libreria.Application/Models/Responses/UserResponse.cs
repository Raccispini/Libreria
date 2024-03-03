using Libreria.Application.Models.Dtos;
using Libreria.Models.Entities;

namespace Libreria.Application.Models.Responses
{
    public class UserResponse
    {
        public UserDto User { get; set; }

        public UserResponse(User user)
        {
            User = UserDto.toDto(user);
        }
    }
}
