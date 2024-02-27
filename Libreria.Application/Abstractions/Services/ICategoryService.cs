using Libreria.Models.Entities;

namespace Libreria.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        void EditCategory(Category category);
        void DeleteCategory(int id);
        ICollection<Category> GetAll();
    }
}
