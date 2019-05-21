using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Lib.Queries.Abstractions;
using MusicStore.Products.Application.Queries.Dtos;
using MusicStore.Products.Core.Products;

namespace MusicStore.Products.Application.Queries
{
    public interface IProductHistoryQuery
    {
        Task<List<ProductHistoryDto>> GetByEmailAsync( string email );
    }
}
