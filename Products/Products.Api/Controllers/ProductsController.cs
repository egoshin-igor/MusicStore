using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Lib.Repositories.Abstractions;
using MusicStore.Products.Api.Dtos;
using MusicStore.Products.Application.AppServices;
using MusicStore.Products.Application.AppServices.Entities;
using MusicStore.Products.Application.Queries;
using MusicStore.Products.Application.Queries.Dtos;

namespace Products.Api.Controllers
{
    [Route( "api/products" )]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductQuery _productQuery;
        private readonly IProductService _productService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductHistoryQuery _productHistoryQuery;

        public ProductsController(
            IProductQuery productQuery,
            IProductService productService,
            IUnitOfWork unitOfWork,
            IProductHistoryQuery productHistoryQuery )
        {
            _productQuery = productQuery;
            _productService = productService;
            _unitOfWork = unitOfWork;
            _productHistoryQuery = productHistoryQuery;
        }

        [HttpGet, Route( "ids" )]
        public async Task<List<int>> GetAllIds()
        {
            return await _productQuery.GetAllIdsAsync();
        }

        [HttpGet, Route( "history" )]
        public async Task<List<ProductHistoryDto>> GetHistory( [FromQuery] string email )
        {
            return await _productHistoryQuery.GetByEmailAsync( email );
        }

        [HttpPost( "by-ids" )]
        public async Task<List<ProductDto>> GetByIdsAsync( [FromBody] List<int> ids )
        {
            return await _productQuery.GetByIdsAsync( ids );
        }

        [HttpPost( "buy" )]
        public async Task<ProductBuiyngResultDto> BuyAsync( [FromBody] BuyTransactionDto buyTransactionDto )
        {
            List<ProductToBuy> productsToBuy = buyTransactionDto.ProductsToBuy.ConvertAll( p => new ProductToBuy
            {
                Id = p.Id,
                PricePerItem = p.PricePerItem,
                Quantity = p.Quantity
            } );

            ProductBuyingResultType resultType = await _productService.BuyAsync( buyTransactionDto.Email, productsToBuy );

            string message = GetMessageByBuyingResult( resultType );
            bool isSuccess = resultType == ProductBuyingResultType.IsSuccess;
            if ( isSuccess )
            {
                await _unitOfWork.CommitAsync();
            }

            return new ProductBuiyngResultDto
            {
                IsSuccess = isSuccess,
                Message = message
            };
        }

        private string GetMessageByBuyingResult( ProductBuyingResultType resultType )
        {
            switch ( resultType )
            {
                case ProductBuyingResultType.ProductsNotFound:
                    return "Selected products not found";
                case ProductBuyingResultType.PriceChanged:
                    return "Product prices changed. Try one more";
                case ProductBuyingResultType.NotEnoughProducts:
                    return "Products qunatity changed. Try one more";
                case ProductBuyingResultType.NotEnoughMoney:
                    return "You hasnt enough money for bying";
                default:
                    return null;
            }
        }
    }
}
