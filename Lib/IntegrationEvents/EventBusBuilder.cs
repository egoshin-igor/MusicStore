using Microsoft.Extensions.DependencyInjection;
using MusicStore.Lib.Bus;
using MusicStore.Lib.Bus.Abstractions;
using MusicStore.Lib.KeyValueStorage;
using MusicStore.Lib.KeyValueStorage.Abstractions;

namespace MusicStore.Lib.IntegrationEvents
{
    public static class EventBusBuilder
    {
        public static IServiceCollection AddEventBus( this IServiceCollection services )
        {
            services.AddSingleton<IKeyValueStorage, RedisStore>();
            services.AddSingleton<IBus, BaseBus>();
            services.AddSingleton<IEventBus, EventBus>();

            return services;
        }
    }
}
