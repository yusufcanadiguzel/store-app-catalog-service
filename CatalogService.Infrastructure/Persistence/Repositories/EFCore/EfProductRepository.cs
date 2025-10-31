using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces;

namespace CatalogService.Infrastructure.Persistence.Repositories.EFCore
{
    public class EfProductRepository : EfEntityRepositoryBase<Product>, IProductRepository
    {
        public EfProductRepository(EfCatalogServiceDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync() => await FindAllAsync();
        public async Task<Product?> GetOneProductByIdAsync(int id) => await FindByConditionAsync(p => p.Id == id);
        public async Task AddProductAsync(Product product) => await CreateAsync(product);
        public async Task UpdateProductAsync(Product product) => await UpdateAsync(product);
        public async Task DeleteProductAsync(Product product) => await DeleteAsync(product);
    }
}
