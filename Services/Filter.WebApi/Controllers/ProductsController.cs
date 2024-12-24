using Filter.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Filter.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var products = await _productService.GetFilteredProductsAsync(null, null, cancellationToken);
            return Ok(products);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetFilteredProducts([FromQuery] string? name, [FromQuery] Guid? subCategoryId, CancellationToken cancellationToken)
        {
            var products = await _productService.GetFilteredProductsAsync(name, subCategoryId, cancellationToken);
            return Ok(products);
        }
    }
}