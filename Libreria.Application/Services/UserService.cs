using Libreria.Application.Abstractions.Services;
using Libreria.Models.Entities;
using Libreria.Models.Repository;

namespace Libreria.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User user)
        {
            _userRepository.Aggiungi(user);
            _userRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            _userRepository.Elimina(id);
            _userRepository.SaveChanges();
        }

        public User Get(int id)
        {
           return _userRepository.Ottieni(id);
        }

        public ICollection<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public void Update(User user)
        {
            _userRepository.Modifica(user);
        }
    }
}
