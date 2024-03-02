using Libreria.Models.Context;
using Libreria.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Models.Repository
{
    public class CategoryRepository : GeneralRepository<Category>
    {
        public CategoryRepository(MyDbContext ctx) : base(ctx)
        {
        }
        
        public new Category Ottieni(int id)
        {
            try
            {
                return _context.Categories.Where(x=>x.id == id).Include(x=>x.books).First();
            }
            catch
            {
                return null;
            }
        }
        public Category GetByName(string name)
        {
            try
            {
                return _context.Categories.Where(x => x.name == name).First();
            }
            catch
            {
                return null;
            }
        }
    }
}
