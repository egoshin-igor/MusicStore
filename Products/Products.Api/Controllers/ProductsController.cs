using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Products.Application.Queries;
using MusicStore.Products.Application.Queries.Dtos;

namespace Products.Api.Controllers
{
    [Route( "api/products" )]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductQuery _productQuery;

        public ProductsController( IProductQuery productQuery )
        {
            _productQuery = productQuery;
        }

        [HttpGet, Route( "ids" )]
        public async Task<List<int>> GetAllIds()
        {
            return await _productQuery.GetAllIdsAsync();
        }

        [HttpPost( "by-ids" )]
        public async Task<List<ProductDto>> GetByIdsAsync( [FromBody] List<int> ids )
        {
            return await _productQuery.GetByIdsAsync( ids );
        }
    }
}
