using Microsoft.AspNetCore.Mvc;
using Libreria.Models.Entities;
using Libreria.Application.Models.Requests;
using Libreria.Application.Services;
using Azure.Core;
using Libreria.Application.Abstractions.Services;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
using Libreria.Application.Models.Responses;
using Libreria.Application.Factories;
namespace ParadigmiLibreria.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class BooksController:ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        [Route("All")]
        
        public IActionResult getLibri( )
        {
            var books = _bookService.getBooks();
            return Ok(ResponseFactory.WithSuccess(new GetAllBooksResponse(books)));
        }

        [HttpGet]
        [Route("Get/{id:int}")]
        public IActionResult getBook(int id)
        {
            var result = _bookService.GetBook(id);
            return Ok(ResponseFactory.WithSuccess(new GetBookResponse(result)));
        }

        [HttpPost]
        [Route("New")]
        public IActionResult CreateBook(CreateBookRequest request)
        {
            var book = request.ToEntity();
            _bookService.AddBook(book);
            return Ok(ResponseFactory.WithSuccess(new NewBookResponse(book)));
        }
        [HttpPut]
        [Route("Edit")]
        public IActionResult EditBook(EditBookRequest request)
        {
            var result = _bookService.EditBook(request.ToEntity());
            return Ok(ResponseFactory.WithSuccess(new NewBookResponse(result)));
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteBook(int id)
        {
            var book = _bookService.GetBook(id);
                _bookService.RemoveBook(id);
                return Ok(ResponseFactory.WithSuccess());
        }
        [HttpPost]
        [Route("Find")]
        public IActionResult FindBook(FindBookRequest request)
        {
             var book = request.ToEntity();
            if (request.AtLeasOneFilter())
            {
                var result = _bookService.Find(book, request.after, request.before, (int)request.pageSize, (int)request.pageCount);
                return Ok(ResponseFactory.WithSuccess(new GetAllBooksResponse(result)));
            }
            else
            {
                throw new Exception("Devi scegliere almeno un filtro");
            }
        }
        
    }
}
