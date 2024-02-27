using Libreria.Models.Entities;

namespace Libreria.Application.Models.Requests
{
    public class EditUserRequest
    {
        public int Id { get; set; }

        public string username { get; set; } = String.Empty;
        public string password { get; set; } = String.Empty;

        public string name { get; set; } = String.Empty;

        public string surname { get; set; } = String.Empty;

        public User ToEntity()
        {
            var user = new User();
            user.id = Id;
            user.username = username;
            user.password = password;
            user.name = name;
            user.surname = surname;
            return user;
        }
    }
}
