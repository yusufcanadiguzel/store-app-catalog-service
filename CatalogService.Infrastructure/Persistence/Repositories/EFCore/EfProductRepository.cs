using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces;

namespace CatalogService.Infrastructure.Persistence.Repositories.EFCore
{
    public class EfProductRepository : EfEntityRepositoryBase<Product>, IProductRepository
    {
        public EfProductRepository(EfCatalogServiceDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Product> GetAllProducts() => FindAll();
        public Product GetOneProductById(int id) => FindByCondition(p => p.Id == id);
        public void AddProduct(Product product) => Create(product);
        public void UpdateProduct(Product product) => Update(product);
        public void DeleteProduct(Product product) => Delete(product);
    }
}
