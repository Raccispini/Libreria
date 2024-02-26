using Microsoft.AspNetCore.Mvc;
using Libreria.Models.Entities;
using Libreria.Application.Models.Requests;
namespace ParadigmiLibreria.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BooksController:ControllerBase
    {
        private List<Book> _books = new List<Book>();

        public BooksController()
        {
            _books.Add(new Book()
            {
                id = 1,
                title = "prova",
                author = "prova autore",
                publisher = "prova publisher",
                relase = new DateTime()
            });
            _books.Add(new Book()
            {
                id = 2,
                title = "prova 2",
                author = "prova autore 2",
                publisher = "prova publisher 2",
                relase = new DateTime()
            });
        }
        [HttpGet]
        [Route("list")]
        public IEnumerable<Book> getLibri()
        {
            return _books;
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public Book getBook(int id)
        {
            return _books.Where(x=>x.id == id).First();
        }

        [HttpPut]
        [Route("new")]
        public IActionResult CreateBook(CreateBookRequest book)
        {
            _books.Add(book.toEntity());
            return Ok();
        }
    }
}
