using Libreria.Application.Models.Dtos;
using Libreria.Models.Entities;

namespace Libreria.Application.Models.Responses
{
    public class UsersResponse
    {
        public ICollection<UserDto> Users { get; set; } = new List<UserDto>();

        public UsersResponse(ICollection<User> users)
        {
            foreach (var user in users)
            {
                Users.Add(UserDto.toDto(user));
            }
        }
    }
}
