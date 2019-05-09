using System.Threading.Tasks;
using MusicStore.Lib.Bus.Abstractions;

namespace MusicStore.Lib.IntegrationEvents
{
    public abstract class IntegrationEventAsyncHandler<TEvent> : IBusMessageAsyncHandler<TEvent> where TEvent : IntegrationEvent
    {
        public abstract Task HandleAsync( TEvent @event );
    }
}
