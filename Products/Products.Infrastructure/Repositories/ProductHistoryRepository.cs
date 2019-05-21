using MusicStore.Lib.Repositories;
using MusicStore.Products.Application.Repositories;
using MusicStore.Products.Core.Products;
using MusicStore.Products.Infrastructure.Foundation;

namespace MusicStore.Products.Infrastructure.Repositories
{
    public class ProductHistoryRepository : Repository<ProductHistory>, IProductHistoryRepository
    {
        public ProductHistoryRepository( ProductsDbContext dbContext ) : base( dbContext )
        {
        }
    }
}
