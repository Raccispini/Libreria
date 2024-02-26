using Libreria.Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        [HttpPut]
        [Route("new")]
        public IActionResult newCategory(CreateCategoryRequest request)
        {
            return Ok();
        }

        [HttpGet]
        [Route("delete")]
        public IActionResult deleteCategory(int id)
        {
            return Ok();
        }
    }
}
