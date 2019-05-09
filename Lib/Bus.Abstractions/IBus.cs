using System;

namespace MusicStore.Lib.Bus.Abstractions
{
    public interface IBus
    {
        void Subscribe<TMessage>( string busName, Action<TMessage> action )
            where TMessage : IBusMessage;

        void Subscribe<TMessage, TMessageHandler>( string busName )
            where TMessage : IBusMessage
            where TMessageHandler : IBusMessageHandler<TMessage>;

        void SubscribeAsync<TMessage, TMessageAsyncHandler>( string busName )
            where TMessage : IBusMessage
            where TMessageAsyncHandler : IBusMessageAsyncHandler<TMessage>;

        void Publish<TMessage>( string busName, TMessage busMessage )
            where TMessage : IBusMessage;
    }
}
