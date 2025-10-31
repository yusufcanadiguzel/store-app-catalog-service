using System.Linq.Expressions;

namespace CatalogService.Domain.Interfaces
{
    public interface IEntityRepositoryBase<T>
    {
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>>? expression = null);
        Task<T?> FindByConditionAsync(Expression<Func<T, bool>> expression);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
