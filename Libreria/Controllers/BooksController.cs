using Microsoft.AspNetCore.Mvc;
using Libreria.Models.Entities;
using Libreria.Application.Models.Requests;
using Libreria.Application.Services;
using Azure.Core;
using Libreria.Application.Abstractions.Services;
namespace ParadigmiLibreria.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BooksController:ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
            
        }
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Book> getLibri()
        {
            return _bookService.getBooks();
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public Book getBook(int id)
        {
            //return _books.Where(x=>x.id == id).First();
            return _bookService.GetBook(id);
        }

        [HttpPut]
        [Route("New")]
        public IActionResult CreateBook(CreateBookRequest request)
        {
            var book = request.ToEntity();
            _bookService.AddBook(book);
            return Ok(book);
        }
        [HttpPost]
        [Route("Edit")]
        public IActionResult EditBook(EditBookRequest request)
        {
            var book = request.ToEntity();
            _bookService.EditBook(book);
            return Ok(book);
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.RemoveBook(id);
            return Ok();
        }

    }
}
