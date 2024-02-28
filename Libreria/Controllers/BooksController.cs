﻿using Microsoft.AspNetCore.Mvc;
using Libreria.Models.Entities;
using Libreria.Application.Models.Requests;
using Libreria.Application.Services;
using Azure.Core;
using Libreria.Application.Abstractions.Services;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public ICollection<Book> getLibri()
        {
            var books = _bookService.getBooks();
            return books;
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
            return Ok(_bookService.EditBook(request.ToEntity()));
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.RemoveBook(id);
            return Ok();
        }
        [HttpPost]
        [Route("Find")]
        public IActionResult FindBook(FindBookRequest request)
        {
             var book = request.ToEntity();
            if (request.after >= request.before)
            {
                return BadRequest("Le date sono discordanti");
            }
             return Ok(_bookService.Find(book,request.after,request.before));
        }
        
    }
}
