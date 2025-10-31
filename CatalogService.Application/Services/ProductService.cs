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

        public async Task CreateOneProductAsync(ProductDtoForCreate productDtoForCreate)
        {
            if (productDtoForCreate is null)
                throw new ArgumentNullException(nameof(productDtoForCreate), "Product cannot be null.");

            var validationResult = _validator.Validate(productDtoForCreate);

            if (!validationResult.IsValid)
                throw new ProductNotValidException(validationResult.ToString());

            await _repositoryService.ProductRepository.CreateAsync(_mapper.Map<Product>(productDtoForCreate));

            await _repositoryService.SaveChangesAsync();
        }

        public async Task DeleteOneProductAsync(int id)
        {
            var entityToDelete = await _repositoryService.ProductRepository.FindByConditionAsync(p => p.Id == id);

            if (entityToDelete is null)
                throw new ProductNotFoundException(id);

            await _repositoryService.ProductRepository.DeleteAsync(entityToDelete);
            await _repositoryService.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _repositoryService.ProductRepository.FindAllAsync();

            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

            return productsDto;
        }

        public async Task<ProductDto> GetOneProductByIdAsync(int id)
        {
            var product = await _repositoryService.ProductRepository.FindByConditionAsync(p => p.Id == id);

            if (product is null)
                throw new ProductNotFoundException(id);

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public async Task UpdateOneProductAsync(int id, ProductDtoForUpdate productDto)
        {
            var entityToUpdate = await _repositoryService.ProductRepository.FindByConditionAsync(p => p.Id == id);

            if (entityToUpdate is null)
                throw new ProductNotFoundException(id);

            _mapper.Map(productDto, entityToUpdate);

            await _repositoryService.ProductRepository.UpdateAsync(entityToUpdate);

            await _repositoryService.SaveChangesAsync();
        }
    }
}
