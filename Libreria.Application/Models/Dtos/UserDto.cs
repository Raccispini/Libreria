using Libreria.Models.Entities;

namespace Libreria.Application.Models.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public static UserDto toDto(User user)
        {
            var dto = new UserDto()
            {
                Id = (int)user.id,
                Name = user.name,
                Surname = user.surname,
                Username = user.username,
                Password = user.password
            };

            return dto;

        }
    }
}
