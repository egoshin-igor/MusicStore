using System;
using Microsoft.Extensions.DependencyInjection;
using MusicStore.Lib.Bus.Abstractions;
using MusicStore.Lib.KeyValueStorage.Abstractions;
using Newtonsoft.Json;

namespace MusicStore.Lib.Bus
{
    public class BaseBus : IBus
    {
        private const string MessagePrefix = "Message_";

        private readonly IKeyValueStorage _keyValueStorage;
        private readonly IServiceProvider _serviceProvider;

        public BaseBus( IKeyValueStorage keyValueStorage, IServiceProvider serviceProvider )
        {
            _keyValueStorage = keyValueStorage;
            _serviceProvider = serviceProvider;
        }
        public void Publish<TMessage>( string busName, TMessage busMessage ) where TMessage : IBusMessage
        {
            string busMessageBody = JsonConvert.SerializeObject( busMessage );
            Type busMessageType = typeof( TMessage );
            string fullEvent = $"{MessagePrefix}{busMessageType.Name}{busMessageBody}";

            _keyValueStorage.Publish( busName, fullEvent );
        }

        public void Subscribe<TMessage, TMessageHandler>( string busName )
            where TMessage : IBusMessage
            where TMessageHandler : IBusMessageHandler<TMessage>
        {
            using ( var scope = _serviceProvider.CreateScope() )
            {
                var messageHandler = ( TMessageHandler )scope.ServiceProvider
                  .GetRequiredService( typeof( TMessageHandler ) );

                Subscribe<TMessage>( busName, ( busMessage ) => messageHandler.Handle( busMessage ) );
            }
        }

        public void Subscribe<TMessage>( string busName, Action<TMessage> action ) where TMessage : IBusMessage
        {
            Type busMessageType = typeof( TMessage );
            string observableMessageName = MessagePrefix + busMessageType.Name;

            _keyValueStorage.Subscribe( busName, ( message ) =>
             {
                 string messageNameFromBus = message.Substring( 0, observableMessageName.Length );
                 if ( messageNameFromBus != observableMessageName )
                     return;

                 string busMessageBody = message.Substring( observableMessageName.Length );
                 TMessage busMessage = JsonConvert.DeserializeObject<TMessage>( busMessageBody );
                 action?.Invoke( busMessage );
             } );
        }

        public void SubscribeAsync<TMessage, TMessageAsyncHandler>( string busName )
            where TMessage : IBusMessage
            where TMessageAsyncHandler : IBusMessageAsyncHandler<TMessage>
        {
            using ( var scope = _serviceProvider.CreateScope() )
            {
                var messageHandler = ( TMessageAsyncHandler )scope.ServiceProvider
                  .GetRequiredService( typeof( TMessageAsyncHandler ) );

                Subscribe<TMessage>( busName, async ( busMessage ) => await messageHandler.HandleAsync( busMessage ) );
            }
        }
    }
}
