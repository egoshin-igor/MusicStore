using System.Threading.Tasks;
using MusicStore.Products.Application.BaseEntities;

namespace MusicStore.Products.Infrastructure.Foundation
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ProductsDbContext DbContext;

        public UnitOfWork( ProductsDbContext dbContext )
        {
            DbContext = dbContext;
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
