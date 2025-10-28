using CatalogService.Application.Exceptions.Abstract;

namespace CatalogService.Application.Exceptions
{
    public sealed class ProductNotValidException : NotValidException
    {
        public ProductNotValidException(string message) : base(message)
        {
        }
    }
}
