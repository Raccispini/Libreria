using Libreria.Application.Abstractions.Services;
using Libreria.Models.Entities;
using Libreria.Models.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Libreria.Application.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void AddCategory(Category category)
        {
            _categoryRepository.Aggiungi(category);
            _categoryRepository.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.Elimina(id);
            _categoryRepository.SaveChanges();
        }

        public void EditCategory(Category category)
        {
           _categoryRepository.Modifica(category);
            _categoryRepository.SaveChanges();
        }

        public ICollection<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        
    }
}
