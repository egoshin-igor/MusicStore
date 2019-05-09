using System;

namespace MusicStore.Lib.IntegrationEvents
{
    public interface IEventBus
    {
        void Subscribe<TEvent, TEventHandler>()
            where TEvent : IntegrationEvent
            where TEventHandler : IntegrationEventHandler<TEvent>;

        void SubscribeAsync<TEvent, TEventAsyncHandler>()
            where TEvent : IntegrationEvent
            where TEventAsyncHandler : IntegrationEventAsyncHandler<TEvent>;

        void Subscribe<TEvent>( Action<TEvent> action )
            where TEvent : IntegrationEvent;

        void Publish<TEvent>( TEvent @event )
            where TEvent : IntegrationEvent;
    }
}