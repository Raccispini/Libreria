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
        List<Book> getBooks();
    }
}
