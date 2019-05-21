using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Backend.Application.Clients;
using MusicStore.Backend.Application.ExternalQuries;
using MusicStore.Backend.Application.ExternalQuries.Dtos;
using MusicStore.Lib.Http.Client;

namespace MusicStore.Backend.Infrastructure.ExternalQueries
{
    public class ProductQuery : IProductQuery
    {
        private readonly IProductClient _productClient;

        public ProductQuery( IProductClient productClient )
        {
            _productClient = productClient;
        }

        public async Task<List<int>> GetAllIdsAsync()
        {
            Response<List<int>> response = await _productClient.GetAsync<List<int>>( "/api/products/ids" );

            return response.Result;
        }

        public async Task<List<ProductDto>> GetByIdsAsync( List<int> ids )
        {
            var response = await _productClient.PostAsync<List<ProductDto>, List<int>>( ids, "/api/products/by-ids" );

            return response.Result;
        }
    }
}
