using Microsoft.Extensions.DependencyInjection;
using MusicStore.Backend.Application.ExternalQuries;
using MusicStore.Backend.Infrastructure.Clients;
using MusicStore.Backend.Infrastructure.ExternalQueries;
using MusicStore.Lib.Repositories;
using MusicStore.Lib.Repositories.Abstractions;

namespace MusicStore.Backend.Infrastructure.Foundation
{
    public static class BackendApplicationBuilder
    {
        public static IServiceCollection BuildBackendApllication( this IServiceCollection services )
        {
            // Application
            services.AddScoped<IProductQuery, ProductQuery>();

            // Infrastructure
            services.AddHttpClient<ProductClient>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
