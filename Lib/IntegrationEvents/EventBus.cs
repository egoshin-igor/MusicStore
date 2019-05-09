using System;
using MusicStore.Lib.Bus.Abstractions;

namespace MusicStore.Lib.IntegrationEvents
{
    public class EventBus : IEventBus
    {
        private const string EventChannelName = "events";
        private readonly IBus _bus;
        public EventBus( IBus bus )
        {
            _bus = bus;
        }

        public void Publish<TEvent>( TEvent @event ) where TEvent : IntegrationEvent
        {
            _bus.Publish( EventChannelName, @event );
        }

        public void Subscribe<TEvent>( Action<TEvent> action ) where TEvent : IntegrationEvent
        {
            _bus.Subscribe( EventChannelName, action );
        }

        public void Subscribe<TEvent, TEventHandler>()
            where TEvent : IntegrationEvent
            where TEventHandler : IntegrationEventHandler<TEvent>
        {
            _bus.Subscribe<TEvent, TEventHandler>( EventChannelName );
        }

        public void SubscribeAsync<TEvent, TEventAsyncHandler>()
            where TEvent : IntegrationEvent
            where TEventAsyncHandler : IntegrationEventAsyncHandler<TEvent>
        {
            _bus.SubscribeAsync<TEvent, TEventAsyncHandler>( EventChannelName );
        }
    }
}