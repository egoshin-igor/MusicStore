using Microsoft.Extensions.DependencyInjection;
using MusicStore.Lib.Repositories;
using MusicStore.Lib.Repositories.Abstractions;
using MusicStore.Products.Application.IntegrationEventHandlers;
using MusicStore.Products.Application.Queries;
using MusicStore.Products.Application.Repositories;
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

            // Repositories
            services.AddScoped<IProductRepository, ProductRepository>();

            // EventHandlers
            services.AddScoped<ProductEditedAsyncHandler>();
            services.AddScoped<ProductAddedAsyncHandler>();

            // Other
            services.AddScoped<IUnitOfWork, UnitOfWork<ProductsDbContext>>();

            return services;
        }
    }
}
