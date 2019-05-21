using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Lib.Repositories.Abstractions;

namespace MusicStore.Lib.Repositories
{
    public class Repository<TEnitiy> : IRepository<TEnitiy> where TEnitiy : class
    {
        private readonly DbContext DbContext;
        protected DbSet<TEnitiy> Entities => DbContext.Set<TEnitiy>();

        public Repository( DbContext dbContext )
        {
            DbContext = dbContext;
        }

        public void Add( TEnitiy entity )
        {
            DbContext.Add( entity );
        }

        public void AddRange( List<TEnitiy> entities )
        {
            DbContext.AddRange( entities );
        }

        public void Remove( TEnitiy entity )
        {
            DbContext.Remove( entity );
        }

        public async Task AddAsync( TEnitiy entity )
        {
            await DbContext.AddAsync( entity );
        }
    }
}
