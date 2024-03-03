using Libreria.Application.Models.Dtos;
using Libreria.Models.Entities;

namespace Libreria.Application.Models.Responses
{
    public class CategoryResponse
    {
        public CategoryDto Category { get; set; }

        public CategoryResponse(Category category)
        {
            Category = CategoryDto.toDto(category);
        }
    }
}
