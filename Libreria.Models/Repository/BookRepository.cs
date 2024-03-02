using Libreria.Models.Context;
using Libreria.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic;
using System.Reflection.Metadata.Ecma335;
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

        public ICollection<Book> findBook(Book book, DateTime? after,DateTime? before, int pageSize,int pageCount)
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
            result = result.Skip((pageCount - 1) * pageSize) // Salta i libri delle pagine precedenti
                .Take(pageSize) // Prendi solo i prossimi 10 libri
                .ToList();
            return result;
        }

        public Book Modifica(Book book)
        {
            //var libro = _context.Books.Find(book.id);
            Book libro;
            try
            {
                libro = _context.Books.Include(x => x.categories).First(x => x.id == book.id);
            }
            catch
            {
                return null;
            }
            
            libro.title=book.title;           
            libro.author = book.author;
            libro.publisher = book.publisher;
            libro.relase = book.relase;
            libro.categories = new List<Category>();
            var tmp = book.categories;
            foreach(var category in tmp)
            {
                Category cat;
                try
                {
                    cat = _context.Categories.Where(x => x.name == category.name).First();
                }
                catch
                {
                    cat = null;
                }
                if (cat == null)
                {
                    _context.Categories.Add(category);
                    _context.SaveChanges();
                    libro.categories.Add(category);
                }
                libro.categories.Add(cat);
            }
            
            //libro.categories = book.categories;
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
                Category cat;
                try
                {
                    cat = _context.Categories.First(x => x.name == category.name);
                }
                catch
                {
                    cat = null;
                }
                if (cat==null)
                {
                    _context.Categories.Add(category);
                    _context.SaveChanges();
                    tmp.Add(_context.Categories.First(x=>x.name == category.name));
                }
                else
                {
                    tmp.Add(cat);
                }
                
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
