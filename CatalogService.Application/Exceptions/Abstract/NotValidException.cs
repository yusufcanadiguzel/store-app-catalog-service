namespace CatalogService.Application.Exceptions.Abstract
{
    public abstract class NotValidException : Exception
    {
        protected NotValidException(string message) : base(message)
        {
            
        }
    }
}
