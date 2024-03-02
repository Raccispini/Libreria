using Libreria.Application.Abstractions;
using Libreria.Models.Entities;

namespace Libreria.Application.Models.Requests
{
    public class SignUpRequest:GeneralRequest<User>
    {
        public string username { get; set; }
        public string password { get; set; }
        public string? name { get; set; } = String.Empty;
        public string? surname { get; set; } = String.Empty;

        public User ToEntity()
        {
            var user = new User();
            user.username = username;
            user.password = password;
            user.name = name;
            user.surname = surname;
            return user;
        }
    }
}
