using AutoMapper;
using CatalogService.Application.DTOs;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Mapping.AutoMapper
{
    public class AmMappingProfile : Profile
    {
        public AmMappingProfile()
        {
            // Product Mappings
            CreateMap<ProductDtoForUpdate, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDtoForCreate, Product>();
        }
    }
}
