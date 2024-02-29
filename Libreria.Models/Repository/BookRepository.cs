using Libreria.Models.Context;
using Libreria.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

namespace Libreria.Models.Repository
{
    public class BookRepository : GeneralRepository<Book>
    {
        public BookRepository(MyDbContext ctx) : base(ctx)
        {
        }
        public new ICollection<Book> GetAll()
        {
            var books = base._context.Books.ToList();
            
            foreach (var book in books)
            {

                var categories = base._context.Books
                    .Where(x=>x.id == book.id)
                    .SelectMany(b => b.categories) 
                    .Select(c => new Category { id = c.id, name = c.name })
                    .Distinct() 
                    .ToList();
                book.categories = categories;
            }

            return books;
        }
        public new Book Ottieni(int id)
        {
            var book = base._context.Books.Where(x=> x.id == id).FirstOrDefault();
            if (book == null)
            {
                return null;
            }
            var categories =  base._context.Books
                    .Where(x => x.id == book.id)
                    .SelectMany(b => b.categories)
                    .Select(c => new Category { id = c.id, name = c.name })
                    .Distinct()
                    .ToList();
            book.categories = categories;
            return book;
        }

        public ICollection<Book> findBook(Book book, DateTime? after,DateTime? before)
        {
            List<Book> result = new List<Book>();
            var books = base._context.Books;
            IQueryable<Book> query = books.Where(x=>x.relase>=after && x.relase<=before);
            if (book.title != String.Empty)
            {
                query = query.Where(x => x.title == book.title);
            }
            if(book.author != String.Empty)
            {
                query = query.Where(x=>x.author == book.author);
            }
            ICollection<Book> tmp = query.ToList();
            foreach (var item in tmp)
            {
                var categories = base._context.Books
                    .Where(x => x.id == item.id)
                    .SelectMany(b => b.categories)
                    .Select(c => new Category { id = c.id, name = c.name })
                .Distinct()
                .ToList();
                if(book.categories.Count() == 0)
                {
                    item.categories = categories;
                    result.Add(item);
                }
                else
                {
                    foreach(var category in categories)
                    {
                        var resetLoop = false;
                        foreach(var filter in book.categories)
                        {
                            if(category.id == filter.id)
                            {
                                item.categories = categories;
                                result.Add(item);
                                resetLoop = true;
                                break;
                            }
                        }
                        if (resetLoop) break;
                    }
                } 
                
            }

            return result;
        }

        public Book Modifica(Book book)
        {
            //var libro = _context.Books.Find(book.id);
            var libro = _context.Books.Include(x => x.categories).FirstOrDefault(x => x.id == book.id);
            if (book.title != String.Empty)
            {
                libro.title=book.title;
            }
            if (book.author != String.Empty)
            {
                libro.author = book.author;
            }
            if (book.publisher != String.Empty)
            {
                libro.publisher = book.publisher;
            }
            if (book.relase != DateTime.MaxValue)
            {
                libro.relase = book.relase;
            }
            if (book.categories.Count()==0)
            {
                libro.categories = new List<Category>();
                var tmp = book.categories;
                foreach(var category in tmp)
                {
                    if (!_context.Categories.Contains(category) && (category.name != String.Empty || category.name != null))
                    {
                        category.id = null;
                        _context.Categories.Add(category);
                        _context.SaveChanges();
                    }
                    libro.categories.Add(category);
                }
            }
            libro.categories = book.categories;
            _context.Update(libro);
            SaveChanges();
            return libro;
        }

        public new void Aggiungi(Book book)
        {
            var categories = book.categories;
            book.categories = [];
            _context.Books.Add(book);
            ICollection<Category> tmp = new List<Category>();
            foreach (var category in categories)
            {
                if (!_context.Categories.Contains(category) && (category.name!=String.Empty || category.name!=null))
                {
                    category.id = null;
                    _context.Categories.Add(category);
                    _context.SaveChanges();
                }
                tmp.Add(_context.Categories.Where(x=>x.id==category.id).FirstOrDefault());
            }
            _context.SaveChanges(); 
            book.categories = tmp;
            _context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
        //public new void Elimina(int id)
        //{
        //    var book = _context.Books.Find(id);
        //    _context.Books.Remove(book);
        //}
    }

}
