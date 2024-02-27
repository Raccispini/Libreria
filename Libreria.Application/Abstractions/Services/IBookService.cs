using Libreria.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Application.Abstractions.Services
{
    public interface IBookService
    {
        ICollection<Book> getBooks();
        void AddBook(Book book);
        void EditBook(Book book);
        void RemoveBook(int id);
        Book GetBook(int id);
    }
}
