using Libreria.Application.Models.Dtos;
using Libreria.Models.Entities;

namespace Libreria.Application.Models.Responses
{
    public class CategoriesResponse
    {
        public ICollection<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        public CategoriesResponse(ICollection<Category> categories)
        {
            foreach (var category in categories)
            {
                Categories.Add(CategoryDto.toDto(category));
            }
        }
    }
}
