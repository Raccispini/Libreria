using Libreria.Models.Context;
using Libreria.Models.Entities;

namespace Libreria.Models.Repository
{
    public class CategoryRepository : GeneralRepository<Category>
    {
        public CategoryRepository(MyDbContext ctx) : base(ctx)
        {
        }
    }
}
