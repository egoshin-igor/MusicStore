using Microsoft.Extensions.DependencyInjection;
using MusicStore.Backend.Application.AppServices;
using MusicStore.Backend.Application.ExternalQuries;
using MusicStore.Backend.Application.Repositories;
using MusicStore.Backend.Infrastructure.Clients;
using MusicStore.Backend.Infrastructure.ExternalQueries;
using MusicStore.Backend.Infrastructure.Repositories;
using MusicStore.Lib.Repositories;
using MusicStore.Lib.Repositories.Abstractions;

namespace MusicStore.Backend.Infrastructure.Foundation
{
    public static class BackendApplicationBuilder
    {
        public static IServiceCollection BuildBackendApllication( this IServiceCollection services )
        {
            // AppServices
            services.AddScoped<IAccountService, AccountService>();

            // Query
            services.AddScoped<IProductQuery, ProductQuery>();

            // Repository
            services.AddScoped<IUserRepository, UserRepository>();

            // Infrastructure
            services.AddHttpClient<ProductClient>();
            services.AddScoped<IUnitOfWork, UnitOfWork<BackendDbContext>>();

            return services;
        }
    }
}
