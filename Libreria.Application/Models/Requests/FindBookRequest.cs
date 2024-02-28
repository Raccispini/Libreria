using Libreria.Application.Abstractions;
using Libreria.Models.Entities;

namespace Libreria.Application.Models.Requests
{
    public class FindBookRequest:GeneralRequest<Book>
    {
        public int? id { get; set; } = null;
        public string? title { get; set; } = string.Empty;
        public string? author { get; set; }= string.Empty;
        public string? publisher { get; set; } = string.Empty;
        //range di date da cercare
        public DateTime? before { get; set; }= DateTime.MaxValue;
        public DateTime? after { get; set;}=DateTime.MinValue;
        //categorie che deve avere il libro
        public ICollection<Category>? categories { get; set; } = new List<Category>();

        public Book ToEntity()
        {
            var book = new Book();
            book.id = id;
            book.author = author;
            book.title = title;
            book.publisher = publisher;
            book.categories = categories;
            return book;
        }
    }
}
