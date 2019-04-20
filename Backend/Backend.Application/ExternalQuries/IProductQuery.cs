using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Backend.Application.ExternalQuries.Dtos;

namespace MusicStore.Backend.Application.ExternalQuries
{
    public interface IProductQuery
    {
        Task<List<int>> GetAllIdsAsync();
        Task<List<ProductDto>> GetByIdsAsync( List<int> ids );
    }
}
