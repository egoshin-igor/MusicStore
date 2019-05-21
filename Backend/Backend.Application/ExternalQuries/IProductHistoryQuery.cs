using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Backend.Application.ExternalQuries.Dtos;

namespace MusicStore.Backend.Application.ExternalQuries
{
    public interface IProductHistoryQuery
    {
        Task<List<ProductHistoryDto>> GetHistoryAsync( string email );
    }
}
