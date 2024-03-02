using Libreria.Application.Abstractions;
using Libreria.Models.Entities;

namespace Libreria.Application.Models.Requests
{
    public class EditBookRequest:GeneralRequest<Book>
    {
        public int? id { get; set; } 

        public string? title { get; set; } = string.Empty;

        public string? author { get; set; } = string.Empty;

        public string? publisher { get; set; } = string.Empty;

        public DateTime? relase { get; set; } = DateTime.MaxValue;

        public ICollection<EditBookCategoriesRequest>? categories { get; set; } = [];

        public Book ToEntity()
        {
            var book = new Book();
            book.id = id;
            book.title = title;
            book.author = author;
            book.publisher = publisher;
            book.relase = (DateTime)relase;
            foreach(var item in categories)
            {
                book.categories.Add(item.ToEntity());
            }
            
            return book;
        }
        public class EditBookCategoriesRequest
        {
            public string name { get; set; }
            public Category ToEntity()
            {
                return new Category()
                {
                    name = this.name,
                };
            }
        }
    }
}
