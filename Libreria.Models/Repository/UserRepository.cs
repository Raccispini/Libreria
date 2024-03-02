using Libreria.Models.Context;
using Libreria.Models.Entities;

namespace Libreria.Models.Repository
{
    public class UserRepository : GeneralRepository<User>
    {
        public UserRepository(MyDbContext ctx) : base(ctx)
        {
        }

        public User getUser(string username, string password)
        {
            return _context.Users.Where(x => x.username == username)
                .Where(x => x.password == password).First();
        }

        public User GetUserByName(string username)
        {
            try
            {
                return _context.Users.Where(x=>x.username == username).First();
            }
            catch
            {
                return null;
            }
        }

        //public bool login(string username,string password)
        //{
        //    var user = _context.Users.Where(x => x.username == username).First();
        //    if (user == null)
        //        return false;
        //    return true;
        //}
    }
}
