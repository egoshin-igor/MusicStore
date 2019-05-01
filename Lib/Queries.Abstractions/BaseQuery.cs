using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MusicStore.Lib.Queries.Abstractions
{
    public abstract class BaseQuery<TEntity> where TEntity : class
    {
        private DbSet<TEntity> _dbSet { get; }
        protected IQueryable<TEntity> Query => _dbSet.AsNoTracking();

        protected BaseQuery( DbContext dbContext )
        {
            _dbSet = dbContext.Set<TEntity>();
        }
    }
}
