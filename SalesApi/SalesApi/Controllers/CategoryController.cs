using Microsoft.AspNetCore.Mvc;
using SalesApi.Services.Interfaces;

namespace SalesApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _categoryService.GetCategoriesAsync();

            return Ok(result);
        }
    }
}
