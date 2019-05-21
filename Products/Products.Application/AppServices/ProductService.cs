using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MusicStore.Lib.IntegrationEvents;
using MusicStore.Products.Application.AppServices.Entities;
using MusicStore.Products.Application.ExternalQueries;
using MusicStore.Products.Application.IntegrationEvents;
using MusicStore.Products.Application.Repositories;
using MusicStore.Products.Core.Products;

namespace MusicStore.Products.Application.AppServices
{
    public interface IProductService
    {
        Task<ProductBuyingResultType> BuyAsync( string email, List<ProductToBuy> productsToBuy );
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productsRepository;
        private readonly IEventBus _eventBus;
        private readonly ITransactionsHistoryQuery _transactionsHistoryQuery;
        private readonly IProductHistoryRepository _productHistoryRepository;

        public ProductService(
            IProductRepository productRepository,
            IEventBus eventBus,
            ITransactionsHistoryQuery transactionsHistoryQuery,
            IProductHistoryRepository productHistoryRepository )
        {
            _productsRepository = productRepository;
            _eventBus = eventBus;
            _transactionsHistoryQuery = transactionsHistoryQuery;
            _productHistoryRepository = productHistoryRepository;
        }

        public async Task<ProductBuyingResultType> BuyAsync( string email, List<ProductToBuy> productsToBuy )
        {
            List<int> productIds = productsToBuy.Select( p => p.Id ).ToList();
            List<Product> products = await _productsRepository.GetByIdsAsync( productIds );
            Dictionary<int, ProductToBuy> productToBuyById = productsToBuy.ToDictionary( p => p.Id, p => p );

            decimal sum = 0;
            foreach ( Product product in products )
            {
                if ( !productToBuyById.ContainsKey( product.Id ) )
                    return ProductBuyingResultType.ProductsNotFound;

                ProductToBuy productToBuy = productToBuyById[ product.Id ];
                if ( product.Price != productToBuy.PricePerItem )
                    return ProductBuyingResultType.PriceChanged;
                if ( product.Quantity < productToBuy.Quantity )
                    return ProductBuyingResultType.NotEnoughProducts;

                product.Buy( productToBuy.Quantity );
                sum += ( productToBuy.Quantity * product.Price );
            }
            string transactionId = Guid.NewGuid().ToString();
            bool isSuccessTranfer = await TranferMoneyToOwnerAsync( email, sum, transactionId );
            if ( !isSuccessTranfer )
                return ProductBuyingResultType.NotEnoughMoney;

            DateTime occuredOnUtc = DateTime.UtcNow;
            foreach ( Product product in products )
            {
                _productHistoryRepository.Add( new ProductHistory(
                    email,
                    product.Title,
                    productToBuyById[ product.Id ].Quantity,
                    product.Price,
                    occuredOnUtc,
                    transactionId
                ) );
            }

            return ProductBuyingResultType.IsSuccess;
        }

        private Task<bool> TranferMoneyToOwnerAsync( string from, decimal sum, string transactionId )
        {
            _eventBus.Publish( new TransferToOwnerRequested
            {
                From = from,
                Sum = sum,
                TransactionId = transactionId
            } );

            return IsSuccessTransactonAsync( transactionId );
        }

        private async Task<bool> IsSuccessTransactonAsync( string transactionId )
        {
            var result = false;

            int retryCount = 5;
            for ( int i = 0; i < retryCount; i++ )
            {
                if ( await _transactionsHistoryQuery.IsSuccessTransaction( transactionId ) )
                {
                    result = true;
                    break;
                }

                Thread.Sleep( 300 );
            }

            return result;
        }
    }
}
