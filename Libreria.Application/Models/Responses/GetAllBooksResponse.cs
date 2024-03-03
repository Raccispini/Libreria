using Libreria.Application.Models.Dtos;
using Libreria.Models.Entities;

namespace Libreria.Application.Models.Responses
{
    public class GetAllBooksResponse
    {
        public ICollection<BookDto> Books { get; set; } = new List<BookDto>();

        public GetAllBooksResponse(ICollection<Book> books)
        {
            foreach(var book in books)
            {
                Books.Add(BookDto.toDTO(book));
            }
        }
    }
}
