using CatalogService.Domain.Interfaces;

namespace CatalogService.Infrastructure.Persistence.Repositories
{
    public class RepositoryManager : IRepositoryService
    {
        private readonly EfCatalogServiceDbContext _dbContext;
        private readonly Lazy<IProductRepository> _productRepository;

        public RepositoryManager(EfCatalogServiceDbContext dbContext, Lazy<IProductRepository> productRepository)
        {
            _dbContext = dbContext;
            _productRepository = productRepository;
        }

        public IProductRepository ProductRepository => _productRepository.Value;

        public Task SaveChangesAsync() => _dbContext.SaveChangesAsync();
    }
}
