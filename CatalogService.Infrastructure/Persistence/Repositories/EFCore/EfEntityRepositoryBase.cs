using CatalogService.Domain.Interfaces;
using System.Linq.Expressions;

namespace CatalogService.Infrastructure.Persistence.Repositories.EFCore
{
    public abstract class EfEntityRepositoryBase<T> : IEntityRepositoryBase<T>
        where T : class, new()
    {
        private readonly EfCatalogServiceDbContext _dbContext;

        public EfEntityRepositoryBase(EfCatalogServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(T entity) => _dbContext.Set<T>().Add(entity);

        public void Delete(T entity) => _dbContext.Set<T>().Remove(entity);

        public IEnumerable<T> FindAll(Expression<Func<T, bool>>? expression = null) => 
            expression != null
            ? _dbContext.Set<T>().Where(expression)
            : _dbContext.Set<T>();

        public T FindByCondition(Expression<Func<T, bool>> expression) =>
            _dbContext.Set<T>().Where(expression).FirstOrDefault();

        public void Update(T entity) => _dbContext.Set<T>().Update(entity);
    }
}
