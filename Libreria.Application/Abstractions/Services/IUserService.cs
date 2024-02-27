using Libreria.Models.Entities;

namespace Libreria.Application.Abstractions.Services
{
    public interface IUserService
    {
        ICollection<User> GetAll();
        void Add(User user);
        void Update(User user);
        void Delete(int id);
        User Get(int id);
    }
}
