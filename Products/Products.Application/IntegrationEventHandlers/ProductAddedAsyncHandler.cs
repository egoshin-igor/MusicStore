using System.Threading.Tasks;
using MusicStore.Lib.IntegrationEvents;
using MusicStore.Lib.Repositories.Abstractions;
using MusicStore.Products.Application.Converters;
using MusicStore.Products.Application.IntegrationEvents;
using MusicStore.Products.Application.Repositories;
using MusicStore.Products.Core.Products;

namespace MusicStore.Products.Application.IntegrationEventHandlers
{
    public class ProductAddedAsyncHandler : IntegrationEventAsyncHandler<ProductAdded>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductAddedAsyncHandler( IProductRepository productRepository, IUnitOfWork unitOfWork )
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public override async Task HandleAsync( ProductAdded @event )
        {
            Product product = new Product( ProductConverter.DtoToInfo( @event.Product ) );
            _productRepository.Add( product );

            await _unitOfWork.CommitAsync();
        }
    }
}
