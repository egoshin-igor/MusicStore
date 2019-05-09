using MusicStore.Lib.Bus.Abstractions;

namespace MusicStore.Lib.IntegrationEvents
{
    public abstract class IntegrationEventHandler<TEvent> : IBusMessageHandler<TEvent> where TEvent : IntegrationEvent
    {
        public abstract void Handle( TEvent @event );
    }
}