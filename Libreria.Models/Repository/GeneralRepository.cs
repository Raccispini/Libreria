using Libreria.Models.Context;

using Libreria.Models.Entities;

namespace Libreria.Models.Repository
{
    public abstract class GeneralRepository<T> where T : class
    {
        protected MyDbContext _context;
        public GeneralRepository(MyDbContext ctx)
        {
            _context = ctx;
        }

        public ICollection<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Aggiungi(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public T Ottieni(int id)
        {
            return _context.Set<T>().Find(id);
        }


        public void Elimina(int id)
        {
            var entity = Ottieni(id);
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public void Modifica(T entity)
        {
           _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
