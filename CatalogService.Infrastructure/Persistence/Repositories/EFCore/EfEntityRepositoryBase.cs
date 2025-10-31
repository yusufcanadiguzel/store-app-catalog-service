using CatalogService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task CreateAsync(T entity) => await _dbContext.Set<T>().AddAsync(entity);

        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>>? expression = null) => 
            expression != null
            ? await _dbContext.Set<T>().Where(expression).ToListAsync()
            : await _dbContext.Set<T>().ToListAsync();

        public async Task<T?> FindByConditionAsync(Expression<Func<T, bool>> expression) =>
            await _dbContext.Set<T>().Where(expression).FirstOrDefaultAsync();

        public Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);

            return Task.CompletedTask;
        }
    }
}
