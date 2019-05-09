using System;
using MusicStore.EmailAgent.Application.IntegrationEventHandlers;
using MusicStore.EmailAgent.Application.IntegrationEvents;
using MusicStore.Lib.IntegrationEvents;

namespace MusicStore.EmailAgent.Infrastructure.Foundation
{
    public static class EventListenersBuilder
    {
        public static void EnableEventListeners( this IServiceProvider serviceProvider )
        {
            var eventBus = ( IEventBus )serviceProvider.GetService( typeof( IEventBus ) );

            eventBus.SubscribeAsync<UserAuthenticated, UserAuthenticatedAsyncHandler>();
        }
    }
}
