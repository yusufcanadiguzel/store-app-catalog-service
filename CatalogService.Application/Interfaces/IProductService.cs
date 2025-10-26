using CatalogService.Application.DTOs;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Interfaces
{
    public interface IProductService
    {
        IQueryable<Product> GetAllProducts();
        Product GetOneProductById(int id);
        Product CreateOneProduct(Product product);
        void UpdateOneProduct(int id, ProductDtoForUpdate productDto);
        void DeleteOneProduct(int id);
    }
}
