using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Lib.Repositories.Abstractions;

namespace MusicStore.Lib.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext DbContext;

        public UnitOfWork( DbContext dbContext )
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
