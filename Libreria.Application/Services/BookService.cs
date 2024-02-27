using Libreria.Application.Abstractions.Services;
using Libreria.Models.Entities;
using Libreria.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Application.Services
{
    public class BookService : IBookService
    {
        private readonly BookRepository _bookRepository;

        public BookService(BookRepository repository)
        {
            this._bookRepository = repository;
        }
        public void AddBook(Book book)
        {
            _bookRepository.Aggiungi(book);
            _bookRepository.SaveChanges();
        }

        public void EditBook(Book book)
        {
            _bookRepository.Modifica(book);
        }

        public Book GetBook(int id)
        {
            return _bookRepository.Ottieni(id);
        }

        public ICollection<Book> getBooks()
        {
            return _bookRepository.GetAll();
        }

        public void RemoveBook(int id)
        {
            _bookRepository.Elimina(id);
        }

        ICollection<Book> IBookService.getBooks()
        {
            return _bookRepository.GetAll();
        }
    }
}
