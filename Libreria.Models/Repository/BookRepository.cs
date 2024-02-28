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
                //var tmp = libro.categories;
                //foreach(var category in tmp)
                //{
                //    libro.categories.Remove(category);
                //}
                foreach(var category in book.categories)
                {
                    libro.categories.Add(category);
                }
            }
            _context.Update(libro);
            SaveChanges();
            libro.categories = book.categories;
            return libro;
        }
    }

}
