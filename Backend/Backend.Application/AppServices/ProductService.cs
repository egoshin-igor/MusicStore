using System;
using System.IO;
using System.Threading.Tasks;
using MusicStore.Backend.Application.AppServices.Entities;
using MusicStore.Backend.Application.Clients;
using MusicStore.Backend.Application.IntegrationEvents;
using MusicStore.Backend.Application.IntegrationEvents.Dtos;
using MusicStore.Backend.Application.Settings;
using MusicStore.Lib.IntegrationEvents;

namespace MusicStore.Backend.Application.AppServices
{
    public interface IProductService
    {
        void Edit( ProductInfo productInfo );
        void Add( ProductInfo productInfo );
        Task<ProductBuiyngResult> BuyAsync( BuyTransactionInfo buyTransactionInfo );
    }

    public class ProductService : IProductService
    {
        private readonly StaticFilesPath _staticFilesPath;
        private readonly IEventBus _eventBus;
        private readonly IProductClient _productClient;

        public ProductService( StaticFilesPath staticFilesPath, IEventBus eventBus, IProductClient productClient )
        {
            _staticFilesPath = staticFilesPath;
            _eventBus = eventBus;
            _productClient = productClient;
        }

        public void Add( ProductInfo productInfo )
        {
            string imagePath = null;
            if ( productInfo.Image != null )
            {
                imagePath = SaveImage( productInfo.Image );
            }

            _eventBus.Publish( new ProductAdded
            {
                Product = new ProductDto
                {
                    Category = productInfo.Category,
                    Description = productInfo.Description,
                    ImagePath = imagePath,
                    Price = productInfo.Price,
                    Quantity = productInfo.Quantity,
                    Title = productInfo.Title
                }
            } );
        }

        public async Task<ProductBuiyngResult> BuyAsync( BuyTransactionInfo buyTransactionInfo )
        {
            var response = await _productClient
                .PostAsync<ProductBuiyngResult, BuyTransactionInfo>( buyTransactionInfo, "api/products/buy" );
            return response.Result;
        }

        public void Edit( ProductInfo productInfo )
        {
            string imagePath = null;
            if ( productInfo.Image != null )
            {
                imagePath = SaveImage( productInfo.Image );
            }

            _eventBus.Publish( new ProductEdited
            {
                Product = new ProductDto
                {
                    Category = productInfo.Category,
                    Description = productInfo.Description,
                    Id = productInfo.Id,
                    ImagePath = imagePath,
                    Price = productInfo.Price,
                    Quantity = productInfo.Quantity,
                    Title = productInfo.Title
                }
            } );
        }

        private string SaveImage( byte[] image )
        {
            string imagePath = null;

            string imageName = Guid.NewGuid().ToString();
            using ( var fs = new FileStream( $"{_staticFilesPath.ImagesFullPath}/{imageName}", FileMode.Create ) )
            {
                fs.Write( image );
            };
            imagePath = $"{_staticFilesPath.ImagesRelativePath}/{imageName}";

            return imagePath;
        }
    }
}
