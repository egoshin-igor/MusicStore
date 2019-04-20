using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Products.Application.Queries.Dtos;

namespace MusicStore.Products.Application.Queries
{
    public interface IProductQuery
    {
        Task<List<int>> GetAllIdsAsync();
        Task<List<ProductDto>> GetByIdsAsync( List<int> ids );
    }
}
