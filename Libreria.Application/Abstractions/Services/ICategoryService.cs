using Libreria.Models.Entities;

namespace Libreria.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        void EditCategory(Category category);
        void DeleteCategory(int id);
        Category GetCategory(int id);
        ICollection<Category> GetAll();
        Category GetCategoryByName(string name);
    }
}
