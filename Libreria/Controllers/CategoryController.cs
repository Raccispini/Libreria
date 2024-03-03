using Libreria.Application.Abstractions.Services;
using Libreria.Application.Factories;
using Libreria.Application.Models.Requests;
using Libreria.Application.Models.Responses;
using Libreria.Models.Entities;
using Libreria.Web.Result;
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
            try
            {
                _categoryService.GetCategoryByName(category.name);
            }
            catch
            {
                _categoryService.AddCategory(category);
                return Ok(ResponseFactory.WithSuccess());
            }
            throw new Exception("Esiste già una categoria con questo nome!");
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult deleteCategory(int id)
        {

            var category = _categoryService.GetCategory(id);
            if (category == null)
            {
                throw new Exception("Categoria non esistente");
            }
            if (category.books.Count() == 0)
            {
                _categoryService.DeleteCategory(id);
                return Ok(ResponseFactory.WithSuccess());
            }
            else
            {
                throw new Exception("La categoria è ancora associata a dei libri");
            }
            
        }
        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            return Ok(ResponseFactory.WithSuccess(new CategoriesResponse(result)));
        }
    }
}
