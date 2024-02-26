using Libreria.Models.Context;
using Libreria.Models.Entities;

namespace Libreria.Models.Repository
{
    public class BookRepository : GeneralRepository<Book>
    {
        public BookRepository(MyDbContext ctx) : base(ctx)
        {

        }
    }
}
