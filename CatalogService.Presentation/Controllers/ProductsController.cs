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
        public IActionResult CreateProduct([FromBody] Product product)
        {
            _serviceManager.ProductService.CreateOneProduct(product);

            return StatusCode(201, product);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneProduct([FromRoute(Name = "id")] int id, [FromBody] Product product)
        {
            var productToUpdate = _serviceManager.ProductService.GetOneProductById(id);

            if (productToUpdate == null)
                return NotFound();

            if (productToUpdate.Id != id)
                return BadRequest("Product ID mismatch.");

            _serviceManager.ProductService.UpdateOneProduct(id, product);

            return Ok(productToUpdate);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneProduct([FromRoute(Name = "id")] int id)
        {
            _serviceManager.ProductService.DeleteOneProduct(id);

            return NoContent();
        }
    }
}
