namespace CatalogService.Domain.Interfaces
{
    public interface IRepositoryService
    {
        IProductRepository ProductRepository { get; }

        Task SaveChangesAsync();
    }
}
