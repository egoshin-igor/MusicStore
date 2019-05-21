using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Lib.Repositories;
using MusicStore.Products.Application.Repositories;
using MusicStore.Products.Core.Products;
using MusicStore.Products.Infrastructure.Foundation;

namespace MusicStore.Products.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository( ProductsDbContext dbContext ) : base( dbContext )
        {
        }

        public async Task<Product> GetByIdAsync( int id )
        {
            return await Entities.FirstOrDefaultAsync( e => e.Id == id );
        }

        public async Task<List<Product>> GetByIdsAsync( List<int> ids )
        {
            return await Entities.Where( e => ids.Contains( e.Id ) ).ToListAsync();
        }
    }
}
