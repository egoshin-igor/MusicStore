using MusicStore.Lib.IntegrationEvents;
using MusicStore.Products.Application.IntegrationEvents.Dtos;

namespace MusicStore.Products.Application.IntegrationEvents
{
    public class ProductAdded : IntegrationEvent
    {
        public ProductDto Product { get; set; }
    }
}
