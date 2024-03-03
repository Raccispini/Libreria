using Libreria.Application.Models.Dtos;
using Libreria.Models.Entities;

namespace Libreria.Application.Models.Responses
{
    public class NewBookResponse
    {
        public BookDto Book { get; set; }

        public NewBookResponse(Book book)
        {
            var dto = BookDto.toDTO(book);
            Book = dto;
        }
    }
}
