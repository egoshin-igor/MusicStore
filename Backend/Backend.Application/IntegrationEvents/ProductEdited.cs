using MusicStore.Backend.Application.IntegrationEvents.Dtos;
using MusicStore.Lib.IntegrationEvents;

namespace MusicStore.Backend.Application.IntegrationEvents
{
    public class ProductEdited : IntegrationEvent
    {
        public ProductDto Product { get; set; }
    }
}
