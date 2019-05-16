using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Backend.Api.Dtos;
using MusicStore.Backend.Application.AppServices;
using MusicStore.Backend.Application.AppServices.Entities;
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
        private readonly IProductService _productEditorService;

        public ShopWindowController( IProductQuery productQuery, IProductService productEditorService )
        {
            _productQuery = productQuery;
            _productEditorService = productEditorService;
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

        [Authorize( Roles = UserRole.Admin )]
        [HttpPost( "products/edit" )]
        public JsonResponse Edit( ProductDto product )
        {
            if ( product == null || product.Id == null )
                return Error( "Product can't be null" );

            _productEditorService.Edit( ProductDtoToServiceEntity( product ) );

            return Success();
        }

        [Authorize( Roles = UserRole.Admin )]
        [HttpPost( "products/add" )]
        public JsonResponse Add( ProductDto product )
        {
            bool isValid =
                product != null
                && product.Id == null
                && product.Image != null
                && product.Price != null
                && product.Quantity != null
                && product.Title != null
                && product.Description != null
                && product.Category != null;

            if ( !isValid )
                return Error( "Product is not valid" );

            _productEditorService.Add( ProductDtoToServiceEntity( product ) );

            return Success();
        }

        private ProductInfo ProductDtoToServiceEntity( ProductDto productDto )
        {
            return new ProductInfo
            {
                Category = productDto.Category,
                Description = productDto.Description,
                Id = productDto.Id,
                Image = productDto.Image,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
                Title = productDto.Title
            };
        }
    }
}
