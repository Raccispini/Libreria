using Libreria.Application.Abstractions;
using Libreria.Models.Entities;

namespace Libreria.Application.Models.Requests
{
    public class EditBookRequest:GeneralRequest<Book>
    {
        public int id { get; set; }

        public string? title { get; set; } = string.Empty;

        public string? author { get; set; } = string.Empty;

        public string? publisher { get; set; } = string.Empty;

        public DateTime? relase { get; set; } = DateTime.Now;

        public ICollection<Category>? categories { get; set; } = [];

        public Book toEntity()
        {
            var book = new Book();
            book.id = id;
            book.title = title;
            book.author = author;
            book.publisher = publisher;
            book.relase = (DateTime)relase;
            book.categories = categories;
            return book;
        }
    }
}
