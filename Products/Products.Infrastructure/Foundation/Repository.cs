using System.Collections.Generic;
using MusicStore.Products.Application.BaseEntities;

namespace MusicStore.Products.Infrastructure.Foundation
{
    class Repository<TEnitiy> : IRepository<TEnitiy> where TEnitiy : class
    {
        protected readonly ProductsDbContext DbContext;

        public Repository( ProductsDbContext dbContext )
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
