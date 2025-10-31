using CatalogService.Application.DTOs;
using CatalogService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ProductsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _serviceManager.ProductService.GetAllProductsAsync();

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneProductByIdAsync([FromRoute(Name = "id")] int id)
        {
            var product = await _serviceManager.ProductService.GetOneProductByIdAsync(id);

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] ProductDtoForCreate productDtoForCreate)
        {
            await _serviceManager.ProductService.CreateOneProductAsync(productDtoForCreate);

            return Created();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneProductAsync([FromRoute(Name = "id")] int id, [FromBody] ProductDtoForUpdate productDto)
        {
            if (productDto is null)
                throw new ArgumentNullException(nameof(productDto), "Product cannot be null.");

            await _serviceManager.ProductService.UpdateOneProductAsync(id, productDto);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneProductAsync([FromRoute(Name = "id")] int id)
        {
            await _serviceManager.ProductService.DeleteOneProductAsync(id);

            return NoContent();
        }
    }
}
