using Libreria.Application.Abstractions.Services;
using Libreria.Application.Models.Requests;
using Libreria.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Web.Controllers
{
    [ApiController]
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
            _categoryService.AddCategory(category);
            return Ok(category);
        }

        [HttpGet]
        [Route("delete")]
        public IActionResult deleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
            return Ok();
        }
        [HttpGet]
        [Route("all")]
        public IEnumerable<Category> GetAll()
        {
            return _categoryService.GetAll();
        }
    }
}
