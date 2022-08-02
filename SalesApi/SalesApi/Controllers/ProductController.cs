using Microsoft.AspNetCore.Mvc;
using SalesApi.Services.Interfaces;

namespace SalesApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{categoryId:Guid}")]
        public async Task<IActionResult> GetAsync(Guid categoryId)
        {
            var result = await _productService.GetProductsByCategoryIdAsync(categoryId);

            return Ok(result);
        }
    }
}
