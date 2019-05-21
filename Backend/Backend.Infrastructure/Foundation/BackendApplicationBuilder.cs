using Microsoft.Extensions.DependencyInjection;
using MusicStore.Backend.Application.AppServices;
using MusicStore.Backend.Application.Clients;
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
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBankTransactionsService, BankTransactionsService>();

            // Query
            services.AddScoped<IProductQuery, ProductQuery>();
            services.AddScoped<IClientQuery, ClientQuery>();
            services.AddScoped<ITransactionsHistoryQuery, TransactionsHistoryQuery>();
            services.AddScoped<IProductHistoryQuery, ProductHistoryQuery>();

            // Repository
            services.AddScoped<IUserRepository, UserRepository>();

            // Clients
            services.AddHttpClient<IProductClient, ProductClient>();
            services.AddHttpClient<BankClient>();

            // Other
            services.AddScoped<IUnitOfWork, UnitOfWork<BackendDbContext>>();

            return services;
        }
    }
}
