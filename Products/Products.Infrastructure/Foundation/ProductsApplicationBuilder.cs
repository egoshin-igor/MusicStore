using Microsoft.Extensions.DependencyInjection;
using MusicStore.Lib.Repositories;
using MusicStore.Lib.Repositories.Abstractions;
using MusicStore.Products.Application.AppServices;
using MusicStore.Products.Application.ExternalQueries;
using MusicStore.Products.Application.IntegrationEventHandlers;
using MusicStore.Products.Application.Queries;
using MusicStore.Products.Application.Repositories;
using MusicStore.Products.Infrastructure.Clients;
using MusicStore.Products.Infrastructure.ExternalQueries;
using MusicStore.Products.Infrastructure.Queries;
using MusicStore.Products.Infrastructure.Repositories;

namespace MusicStore.Products.Infrastructure.Foundation
{
    public static class ProductsApplicationBuilder
    {
        public static IServiceCollection BuildProductsApllication( this IServiceCollection services )
        {
            // Queries
            services.AddScoped<IProductQuery, ProductQuery>();
            services.AddScoped<IProductHistoryQuery, ProductHistoryQuery>();

            // ExternalQueries
            services.AddScoped<ITransactionsHistoryQuery, TransactionsHistoryQuery>();

            // Repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductHistoryRepository, ProductHistoryRepository>();

            // AppServices
            services.AddScoped<IProductService, ProductService>();

            // EventHandlers
            services.AddScoped<ProductEditedAsyncHandler>();
            services.AddScoped<ProductAddedAsyncHandler>();

            // Clients
            services.AddHttpClient<IBankClient, BankClient>();

            // Other
            services.AddScoped<IUnitOfWork, UnitOfWork<ProductsDbContext>>();

            return services;
        }
    }
}
