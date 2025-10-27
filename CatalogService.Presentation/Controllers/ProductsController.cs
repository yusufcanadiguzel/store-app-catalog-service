using CatalogService.Application.DTOs;
using CatalogService.Application.Interfaces;
using CatalogService.Domain.Entities;
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
        public IActionResult GetAllProducts()
        {
            var products = _serviceManager.ProductService.GetAllProducts();

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneProductById([FromRoute(Name = "id")] int id)
        {
            var product = _serviceManager.ProductService.GetOneProductById(id);

            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDtoForCreate productDtoForCreate)
        {
            _serviceManager.ProductService.CreateOneProduct(productDtoForCreate);

            return Created();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneProduct([FromRoute(Name = "id")] int id, [FromBody] ProductDtoForUpdate productDto)
        {
            if (productDto is null)
                throw new ArgumentNullException(nameof(productDto), "Product cannot be null.");

            _serviceManager.ProductService.UpdateOneProduct(id, productDto);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneProduct([FromRoute(Name = "id")] int id)
        {
            _serviceManager.ProductService.DeleteOneProduct(id);

            return NoContent();
        }
    }
}
