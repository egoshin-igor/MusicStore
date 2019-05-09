using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Lib.Repositories.Abstractions;

namespace MusicStore.Lib.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork
         where T : DbContext
    {
        protected readonly T DbContext;

        public UnitOfWork( T dbContext )
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
