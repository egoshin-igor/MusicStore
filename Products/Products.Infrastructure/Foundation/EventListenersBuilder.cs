using System;
using MusicStore.Lib.IntegrationEvents;
using MusicStore.Products.Application.IntegrationEventHandlers;
using MusicStore.Products.Application.IntegrationEvents;

namespace MusicStore.Products.Infrastructure.Foundation
{
    public static class EventListenersBuilder
    {
        public static void EnableEventListeners( this IServiceProvider serviceProvider )
        {
            var eventBus = ( IEventBus )serviceProvider.GetService( typeof( IEventBus ) );

            eventBus.SubscribeAsync<ProductEdited, ProductEditedAsyncHandler>();
            eventBus.SubscribeAsync<ProductAdded, ProductAddedAsyncHandler>();
        }
    }
}
