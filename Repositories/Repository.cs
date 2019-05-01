using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MusicStore.Lib.Repositories.Abstractions;

namespace MusicStore.Lib.Repositories
{
    public class Repository<TEnitiy> : IRepository<TEnitiy> where TEnitiy : class
    {
        protected readonly DbContext DbContext;

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
    }
}
