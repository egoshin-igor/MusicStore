using System;
using MusicStore.Lib.KeyValueStorage.Abstractions;
using StackExchange.Redis;

namespace MusicStore.Lib.KeyValueStorage
{
    public class RedisStore : IKeyValueStorage
    {
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection;

        static RedisStore()
        {
            var configurationOptions = new ConfigurationOptions
            {
                AbortOnConnectFail = false,
                EndPoints = { "localhost:6379" }
            };

            LazyConnection = new Lazy<ConnectionMultiplexer>( () => ConnectionMultiplexer.Connect( configurationOptions ) );
        }

        private static ConnectionMultiplexer Connection => LazyConnection.Value;

        public void Publish( string channel, string message )
        {
            ISubscriber subscriber = Connection.GetSubscriber();
            subscriber.Publish( channel, message );
        }

        public void Subscribe( string channel, Action<string> action )
        {
            ISubscriber subscriber = Connection.GetSubscriber();
            subscriber.Subscribe( channel, ( redisChannel, message ) => action( message ) );
        }
    }
}