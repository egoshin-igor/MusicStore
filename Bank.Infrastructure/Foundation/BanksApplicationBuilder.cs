using Microsoft.Extensions.DependencyInjection;
using MusicStore.Bank.Application.IntegrationEventHandlers;
using MusicStore.Bank.Application.Queries;
using MusicStore.Bank.Application.Repositories;
using MusicStore.Bank.Infrastructure.Queries;
using MusicStore.Bank.Infrastructure.Repositories;
using MusicStore.Lib.Repositories;
using MusicStore.Lib.Repositories.Abstractions;

namespace MusicStore.Banks.Infrastructure.Foundation
{
    public static class BanksApplicationBuilder
    {
        public static IServiceCollection BuildBanksApllication( this IServiceCollection services )
        {
            // Queries
            services.AddScoped<IClientQuery, ClientQuery>();
            services.AddScoped<ITransactionsHistoryQuery, TransactionsHistoryQuery>();

            // Repositories
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ITransactionsHistoryRepository, TransactionsHistoryRepository>();

            // EventHandlers
            services.AddScoped<UserHasBeenAddedAsyncHandler>();
            services.AddScoped<ChangeClientBalanceRequestedAsyncHandler>();
            services.AddScoped<TransferTransactionRequestedAsyncHandler>();
            services.AddScoped<TransferToOwnerRequestedAsyncHandler>();

            // Other
            services.AddScoped<IUnitOfWork, UnitOfWork<BanksDbContext>>();

            return services;
        }
    }
}
