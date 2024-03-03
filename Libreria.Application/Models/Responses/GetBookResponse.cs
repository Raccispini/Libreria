using Libreria.Application.Models.Dtos;
using Libreria.Models.Entities;

namespace Libreria.Application.Models.Responses
{
    public class GetBookResponse
    {
        public BookDto Book { get; set; }

        public GetBookResponse(Book book)
        {
            var dto = BookDto.toDTO(book);
            Book = dto;
        }
    }
}
