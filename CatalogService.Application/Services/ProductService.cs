using AutoMapper;
using CatalogService.Application.DTOs;
using CatalogService.Application.Exceptions;
using CatalogService.Application.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Domain.Exceptions;
using CatalogService.Domain.Interfaces;
using FluentValidation;

namespace CatalogService.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        private readonly IValidator<ProductDtoForCreate> _validator;

        public ProductService(IRepositoryService repositoryService, IMapper mapper, IValidator<ProductDtoForCreate> validator)
        {
            _repositoryService = repositoryService;
            _mapper = mapper;
            _validator = validator;
        }

        public void CreateOneProduct(ProductDtoForCreate productDtoForCreate)
        {
            if (productDtoForCreate is null)
                throw new ArgumentNullException(nameof(productDtoForCreate), "Product cannot be null.");

            var validationResult = _validator.Validate(productDtoForCreate);

            if (!validationResult.IsValid)
                throw new ProductNotValidException(validationResult.ToString());

            _repositoryService.ProductRepository.Create(_mapper.Map<Product>(productDtoForCreate));

            _repositoryService.SaveChanges();
        }

        public void DeleteOneProduct(int id)
        {
            var entityToDelete = _repositoryService.ProductRepository.FindByCondition(p => p.Id == id);

            if (entityToDelete is null)
                throw new ProductNotFoundException(id);

            _repositoryService.ProductRepository.Delete(entityToDelete);
            _repositoryService.SaveChanges();
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var products = _repositoryService.ProductRepository.FindAll();

            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

            return productsDto;
        }

        public ProductDto GetOneProductById(int id)
        {
            var product = _repositoryService.ProductRepository.FindByCondition(p => p.Id == id);

            if (product is null)
                throw new ProductNotFoundException(id);

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public void UpdateOneProduct(int id, ProductDtoForUpdate productDto)
        {
            var entityToUpdate = _repositoryService.ProductRepository.FindByCondition(p => p.Id == id);

            if (entityToUpdate is null)
                throw new ProductNotFoundException(id);

            _mapper.Map(productDto, entityToUpdate);

            _repositoryService.ProductRepository.Update(entityToUpdate);

            _repositoryService.SaveChanges();
        }
    }
}
