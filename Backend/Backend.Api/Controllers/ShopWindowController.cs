using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Backend.Application.ExternalQuries;
using MusicStore.Backend.Application.ExternalQuries.Dtos;
using Newtonsoft.Json;

namespace MusicStore.Backend.Api.Controllers
{
    [Route( "api/shop-window" )]
    [ApiController]
    public class ShopWindowController : ControllerBase
    {
        IProductQuery _productQuery;

        public ShopWindowController( IProductQuery productQuery )
        {
            _productQuery = productQuery;
        }

        [HttpGet, Route( "products-ids" )]
        public async Task<string> GetAllIds()
        {
            Console.WriteLine( 2 );
            string result = JsonConvert.SerializeObject( await _productQuery.GetAllIdsAsync() );
            Console.WriteLine( result );
            return result;
        }

        [HttpPost( "products" )]
        public async Task<string> GetByIdsAsync( [FromBody] List<int> ids )
        {
            Console.WriteLine( 1 );
            string result = JsonConvert.SerializeObject( await _productQuery.GetByIdsAsync( ids ) );
            Console.WriteLine( result );
            return result;
        }
    }
}
