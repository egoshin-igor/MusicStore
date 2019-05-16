using MusicStore.Lib.IntegrationEvents;
using MusicStore.Products.Application.IntegrationEvents.Dtos;

namespace MusicStore.Products.Application.IntegrationEvents
{
    public class ProductEdited : IntegrationEvent
    {
        public ProductDto Product { get; set; }
    }
}
