using Libreria.Models.Entities;

namespace Libreria.Application.Models.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static CategoryDto toDto(Category category)
        {
            var dto = new CategoryDto();
            dto.Id = (int)category.id;
            dto.Name = category.name;
            return dto;
        }
    }
}
