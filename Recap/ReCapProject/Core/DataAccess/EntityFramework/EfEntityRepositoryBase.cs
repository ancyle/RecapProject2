using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            await using TContext context = new();
            var entry = context.Entry(entity);
            entry.State = EntityState.Added;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await using TContext context = new();
            var entry = context.Entry(entity);
            entry.State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            await using TContext context = new();
            return filter == null
                ? await context.Set<TEntity>().ToListAsync()
                : await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            await using TContext context = new();
            return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await using TContext context = new();
            var entry = context.Entry(entity);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
