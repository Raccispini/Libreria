using Libreria.Application.Abstractions;
using Libreria.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Application.Models.Requests
{
    public class CreateBookRequest : GeneralRequest<Book>
    {

        public string title { get; set; } = string.Empty;

        public string author { get; set; } = string.Empty;

        public string publisher { get; set; } = string.Empty;

        public DateTime relase { get; set; } = DateTime.Now;

        public ICollection<CreateCategoryRequest> categories { get; set; } = [];

        public Book ToEntity()
        {
            var book = new Book();
            book.title = title;
            book.author = author;
            book.publisher = publisher;
            book.relase = relase;
            foreach(var block in categories)
            {
                book.categories.Add(block.ToEntity());
            }
            return book;
        }
    }
}
