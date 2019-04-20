using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MusicStore.Products.Infrastructure.Foundation
{
    public class BaseQuery<TEntity> where TEntity : class
    {
        private DbSet<TEntity> _dbSet { get; }
        protected IQueryable<TEntity> Query => _dbSet.AsNoTracking();

        public BaseQuery( ProductsDbContext dbContext )
        {
            _dbSet = dbContext.Set<TEntity>();
        }
    }
}
