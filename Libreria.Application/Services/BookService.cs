using Libreria.Application.Abstractions.Services;
using Libreria.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Application.Services
{
    public class BookService : IBookService
    {

        public List<Book> getBooks()
        {
            return new List<Book>();
        }
    }
}
