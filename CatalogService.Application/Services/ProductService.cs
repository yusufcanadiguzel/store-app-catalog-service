using AutoMapper;
using CatalogService.Application.DTOs;
using CatalogService.Application.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces;

namespace CatalogService.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryService repositoryService, IMapper mapper)
        {
            _repositoryService = repositoryService;
            _mapper = mapper;
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
                throw new Exception($"Product with ID {id} could not found.");

            _repositoryService.ProductRepository.Delete(entityToDelete);
            _repositoryService.SaveChanges();
        }

        public IQueryable<Product> GetAllProducts()
        {
            return _repositoryService.ProductRepository.FindAll();
        }

        public Product GetOneProductById(int id)
        {
            return _repositoryService.ProductRepository.FindByCondition(p => p.Id == id);
        }

        public void UpdateOneProduct(int id, ProductDtoForUpdate productDto)
        {
            var entityToUpdate = _repositoryService.ProductRepository.FindByCondition(p => p.Id == id);

            if (entityToUpdate is null)
                throw new Exception($"Product with ID {id} could not found.");

            _mapper.Map(productDto, entityToUpdate);

            _repositoryService.ProductRepository.Update(entityToUpdate);

            _repositoryService.SaveChanges();
        }
    }
}
