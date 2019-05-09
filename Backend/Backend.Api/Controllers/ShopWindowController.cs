using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Backend.Application.BaseEntity;
using MusicStore.Backend.Application.Entities.Users;
using MusicStore.Backend.Application.ExternalQuries;

namespace MusicStore.Backend.Api.Controllers
{
    [Route( "api/shop-window" )]
    [ApiController]
    public class ShopWindowController : JsonController
    {
        private readonly IProductQuery _productQuery;

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

        [HttpGet( "any-rights" )]
        public JsonResponse CheckAnyRights()
        {
            return Success( "any-rights" );
        }

        [Authorize( Roles = UserRole.User )]
        [HttpGet( "user-rights" )]
        public JsonResponse CheckUserRights()
        {
            return Success( "user-rights" );
        }

        [Authorize( Roles = UserRole.Admin )]
        [HttpGet( "admin-rights" )]
        public JsonResponse CheckAdminRights()
        {
            return Success( "admin-rights" );
        }
    }
}
