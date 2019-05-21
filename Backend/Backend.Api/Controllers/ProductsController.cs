using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Backend.Api.Converters;
using MusicStore.Backend.Api.Converters.Entities;
using MusicStore.Backend.Api.Dtos;
using MusicStore.Backend.Application.AppServices;
using MusicStore.Backend.Application.AppServices.Entities;
using MusicStore.Backend.Application.BaseEntity;
using MusicStore.Backend.Application.ExternalQuries;
using MusicStore.Backend.Application.ExternalQuries.Dtos;

namespace MusicStore.Backend.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route( "api/products" )]
    public class ProductsController : JsonController
    {
        private readonly IProductService _productService;
        private readonly IProductHistoryQuery _productHistoryQuery;

        public ProductsController( IProductService productService, IProductHistoryQuery productHistoryQuery )
        {
            _productService = productService;
            _productHistoryQuery = productHistoryQuery;
        }

        [HttpGet, Route( "history" )]
        public async Task<IActionResult> GetHistoryAsync()
        {
            List<ProductHistoryDto> historyProducts = await _productHistoryQuery.GetHistoryAsync( Email );
            ProductsHistory result = ProductHistoryConverter.Convert( historyProducts );
            return Ok( result );
        }

        [HttpPost, Route( "buy" )]
        public async Task<IActionResult> BuyAsync( [FromBody] BuyTransactionDto buyTransactionDto )
        {
            if ( buyTransactionDto == null || buyTransactionDto.ProductsToBuy == null || buyTransactionDto.ProductsToBuy.Count == 0 )
                return BadRequest();
            ProductBuiyngResult result = await _productService.BuyAsync( DtoToEntity( buyTransactionDto ) );

            return Ok( result );
        }

        private BuyTransactionInfo DtoToEntity( BuyTransactionDto buyTransactionDto )
        {
            return new BuyTransactionInfo
            {
                Email = Email,
                ProductsToBuy = buyTransactionDto.ProductsToBuy.ConvertAll( p => new ProductToBuy
                {
                    Id = p.Id,
                    PricePerItem = p.PricePerItem,
                    Quantity = p.Quantity
                } )
            };
        }
    }
}
