using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Backend.Application.BaseEntity;
using MusicStore.Backend.Application.ExternalQuries;
using MusicStore.Backend.Application.ExternalQuries.Dtos;
using Newtonsoft.Json;

namespace MusicStore.Backend.Api.Controllers
{
    [Route( "api/shop-window" )]
    [ApiController]
    public class ShopWindowController : JsonController
    {
        IProductQuery _productQuery;

        public ShopWindowController( IProductQuery productQuery )
        {
            _productQuery = productQuery;
        }

        [HttpGet, Route( "products-ids" )]
        public async Task<JsonResponse> GetAllIds()
        {
            return Success( await _productQuery.GetAllIdsAsync() );
        }

        [HttpPost( "products" )]
        public async Task<JsonResponse> GetByIdsAsync( [FromBody] List<int> ids )
        {
            return Success( await _productQuery.GetByIdsAsync( ids ) );
        }
    }
}
