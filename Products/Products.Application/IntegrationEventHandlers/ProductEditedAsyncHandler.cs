using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MusicStore.Lib.IntegrationEvents;
using MusicStore.Lib.Repositories.Abstractions;
using MusicStore.Products.Application.Converters;
using MusicStore.Products.Application.IntegrationEvents;
using MusicStore.Products.Application.Repositories;
using MusicStore.Products.Application.Settings;
using MusicStore.Products.Core.Products;

namespace MusicStore.Products.Application.IntegrationEventHandlers
{
    public class ProductEditedAsyncHandler : IntegrationEventAsyncHandler<ProductEdited>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly StaticFilesPath _staticFilesPath;

        public ProductEditedAsyncHandler( IProductRepository productRepository, IUnitOfWork unitOfWork, StaticFilesPath staticFilesPath )
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _staticFilesPath = staticFilesPath;
        }

        public override async Task HandleAsync( ProductEdited @event )
        {
            Product product = await _productRepository.GetByIdAsync( @event.Product.Id.Value );
            if ( product == null )
                throw new ApplicationException( $"Product {@event.Product.Id} not found while has edited" );

            string oldImageRelativePath = product.ImagePath;
            product.Update( ProductConverter.DtoToInfo( @event.Product ) );

            await _unitOfWork.CommitAsync();
            if ( @event.Product.ImagePath != null )
            {
                string imageName = oldImageRelativePath.Split( '/' ).Last();
                var path = Path.GetFullPath( $"{_staticFilesPath.ImagesFullPath}/{imageName}" );
                File.Delete( path );
            }
        }
    }
}
