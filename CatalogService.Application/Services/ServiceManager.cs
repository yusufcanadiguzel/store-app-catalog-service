using CatalogService.Application.Interfaces;

namespace CatalogService.Application.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _productService;

        public ServiceManager(Lazy<IProductService> productService)
        {
            _productService = productService;
        }

        public IProductService ProductService => _productService.Value;
    }
}
