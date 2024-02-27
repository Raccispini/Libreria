using Libreria.Application.Abstractions;
using Libreria.Models.Entities;

namespace Libreria.Application.Models.Requests
{
    public class CreateCategoryRequest : GeneralRequest<Category>
    {
        public string name { get; set; } = String.Empty;

        public Category ToEntity()
        {
            var category = new Category();
            category.name = name;
            return category;
        }
    }
}
