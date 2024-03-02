using Libreria.Application.Abstractions.Services;
using Libreria.Application.Models.Requests;
using Libreria.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Web.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPut]
        [Route("new")]
        public IActionResult newCategory(CreateCategoryRequest request)
        {
            var category = request.ToEntity();
            if (_categoryService.GetCategoryByName(request.name) == null)
            {
                _categoryService.AddCategory(category);
                return Ok();
            }
            return BadRequest("Esiste già una categoria con questo nome!");
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult deleteCategory(int id)
        {

            var category = _categoryService.GetCategory(id);
            if (category == null)
            {
                return BadRequest("Categoria non esistente");
            }
            if (category.books.Count() == 0)
            {
                _categoryService.DeleteCategory(id);
                return Ok();
            }
            else
            {
                return BadRequest("La categoria è ancora associata a dei libri");
            }
            
        }
        [HttpGet]
        [Route("all")]
        public IEnumerable<Category> GetAll()
        {
            return _categoryService.GetAll();
        }
    }
}
