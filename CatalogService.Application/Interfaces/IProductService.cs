using CatalogService.Application.DTOs;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetOneProductByIdAsync(int id);
        Task CreateOneProductAsync(ProductDtoForCreate product);
        Task UpdateOneProductAsync(int id, ProductDtoForUpdate productDto);
        Task DeleteOneProductAsync(int id);
    }
}
