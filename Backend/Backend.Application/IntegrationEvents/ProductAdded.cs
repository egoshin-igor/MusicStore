using MusicStore.Backend.Application.IntegrationEvents.Dtos;
using MusicStore.Lib.IntegrationEvents;

namespace MusicStore.Backend.Application.IntegrationEvents
{
    public class ProductAdded : IntegrationEvent
    {
        public ProductDto Product { get; set; }
    }
}
