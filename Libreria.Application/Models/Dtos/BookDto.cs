using Libreria.Models.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Libreria.Application.Models.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime Relase { get; set; }
        public ICollection<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        public static BookDto toDTO(Book book)
        {
            var BookDto = new BookDto();
            BookDto.Id = (int)book.id;
            BookDto.Title = book.title;
            BookDto.Author = book.author;
            BookDto.Publisher = book.publisher;
            BookDto.Relase = book.relase;
            foreach(var item in book.categories)
            {
                var dto = CategoryDto.toDto(item);
                BookDto.Categories.Add(dto);
            }
            return BookDto;
        }
    }
}
