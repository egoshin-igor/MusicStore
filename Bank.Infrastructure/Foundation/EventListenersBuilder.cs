using System;
using MusicStore.Bank.Application.IntegrationEventHandlers;
using MusicStore.Bank.Application.IntegrationEvents;
using MusicStore.Lib.IntegrationEvents;

namespace MusicStore.Banks.Infrastructure.Foundation
{
    public static class EventListenersBuilder
    {
        public static void EnableEventListeners( this IServiceProvider serviceProvider )
        {
            var eventBus = ( IEventBus )serviceProvider.GetService( typeof( IEventBus ) );

            eventBus.SubscribeAsync<UserHasBeenAdded, UserHasBeenAddedAsyncHandler>();
            eventBus.SubscribeAsync<ChangeClientBalanceRequested, ChangeClientBalanceRequestedAsyncHandler>();
            eventBus.SubscribeAsync<TransferTransactionRequested, TransferTransactionRequestedAsyncHandler>();
            eventBus.SubscribeAsync<TransferToOwnerRequested, TransferToOwnerRequestedAsyncHandler>();
        }
    }
}
