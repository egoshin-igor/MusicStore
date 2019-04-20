using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Products.Application.Queries;
using MusicStore.Products.Application.Queries.Dtos;
using MusicStore.Products.Core.Products;
using MusicStore.Products.Infrastructure.Foundation;

namespace MusicStore.Products.Infrastructure.Queries
{
    class ProductQuery : BaseQuery<Product>, IProductQuery
    {
        public ProductQuery( ProductsDbContext dbContext ) : base( dbContext )
        {
        }

        public async Task<List<int>> GetAllIdsAsync()
        {
            List<int> ids = await Query.Select( q => q.Id ).ToListAsync();
            if ( ids == null )
                return new List<int>();

            return ids;
        }

        public async Task<List<ProductDto>> GetByIdsAsync( List<int> ids )
        {
            List<Product> products = await Query.Where( q => ids.Contains( q.Id ) ).ToListAsync();
            if ( products == null )
                return new List<ProductDto>();

            return products.Select( p => new ProductDto
            {
                Title = p.Title,
                Category = p.Category,
                Description = p.Description,
                Id = p.Id,
                ImagePath = p.ImagePath,
                Quantity = p.Quantity
            } ).ToList();
        }
    }
}
