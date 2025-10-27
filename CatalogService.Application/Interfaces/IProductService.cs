using CatalogService.Application.DTOs;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto GetOneProductById(int id);
        void CreateOneProduct(ProductDtoForCreate product);
        void UpdateOneProduct(int id, ProductDtoForUpdate productDto);
        void DeleteOneProduct(int id);
    }
}
