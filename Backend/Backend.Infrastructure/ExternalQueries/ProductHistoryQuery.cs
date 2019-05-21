using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Backend.Application.Clients;
using MusicStore.Backend.Application.ExternalQuries;
using MusicStore.Backend.Application.ExternalQuries.Dtos;

namespace MusicStore.Backend.Infrastructure.ExternalQueries
{
    public class ProductHistoryQuery : IProductHistoryQuery
    {
        private readonly IProductClient _productClient;

        public ProductHistoryQuery( IProductClient productClient )
        {
            _productClient = productClient;
        }

        public async Task<List<ProductHistoryDto>> GetHistoryAsync( string email )
        {
            var response = await _productClient.GetAsync<List<ProductHistoryDto>>( $"api/products/history?email={email}" );
            return response.Result;
        }
    }
}
