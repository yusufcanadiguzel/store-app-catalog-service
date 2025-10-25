using CatalogService.Application.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Domain.Exceptions;
using CatalogService.Domain.Interfaces;

namespace CatalogService.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryService _repositoryService;

        public ProductService(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        public Product CreateOneProduct(Product product)
        {
            if (product is null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");

            _repositoryService.ProductRepository.Create(product);
            _repositoryService.SaveChanges();

            return product;
        }

        public void DeleteOneProduct(int id)
        {
            var entityToDelete = _repositoryService.ProductRepository.FindByCondition(p => p.Id == id);

            if (entityToDelete is null)
                throw new ProductNotFoundException(id);

            _repositoryService.ProductRepository.Delete(entityToDelete);
            _repositoryService.SaveChanges();
        }

        public IQueryable<Product> GetAllProducts()
        {
            return _repositoryService.ProductRepository.FindAll();
        }

        public Product GetOneProductById(int id)
        {
            var product = _repositoryService.ProductRepository.FindByCondition(p => p.Id == id);

            if (product is null)
                throw new ProductNotFoundException(id);

            return product;
        }

        public void UpdateOneProduct(int id, Product product)
        {
            var entityToUpdate = _repositoryService.ProductRepository.FindByCondition(p => p.Id == id);

            if (entityToUpdate is null)
                throw new ProductNotFoundException(id);

            if (product is null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");

            entityToUpdate.Name = product.Name;
            entityToUpdate.Description = product.Description;
            entityToUpdate.Price = product.Price;
            entityToUpdate.UnitsInStock = product.UnitsInStock;
            entityToUpdate.IsActive = product.IsActive;

            _repositoryService.ProductRepository.Update(entityToUpdate);
            _repositoryService.SaveChanges();
        }
    }
}
