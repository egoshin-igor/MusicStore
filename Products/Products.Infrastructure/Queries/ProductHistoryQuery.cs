using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Lib.Queries.Abstractions;
using MusicStore.Products.Application.Queries;
using MusicStore.Products.Application.Queries.Dtos;
using MusicStore.Products.Core.Products;
using MusicStore.Products.Infrastructure.Foundation;

namespace MusicStore.Products.Infrastructure.Queries
{
    public class ProductHistoryQuery : BaseQuery<ProductHistory>, IProductHistoryQuery
    {
        public ProductHistoryQuery( ProductsDbContext dbContext ) : base( dbContext )
        {
        }

        public async Task<List<ProductHistoryDto>> GetByEmailAsync( string email )
        {
            List<ProductHistory> query = await Query.Where( q => q.Email == email ).ToListAsync();

            return query.Select( q => new ProductHistoryDto
            {
                OccuredOnUtc = q.OccuredOnUtc,
                PricePerItem = q.PricePerItem,
                ProductName = q.ProductName,
                Quantity = q.Qunatity,
                TransactionId = q.TransactionId
            } ).ToList();
        }
    }
}
