using Microsoft.Extensions.DependencyInjection;
using MusicStore.Lib.Repositories;
using MusicStore.Lib.Repositories.Abstractions;
using MusicStore.Products.Application.Queries;
using MusicStore.Products.Infrastructure.Queries;

namespace MusicStore.Products.Infrastructure.Foundation
{
    public static class ProductsApplicationBuilder
    {
        public static IServiceCollection BuildProductsApllication( this IServiceCollection services )
        {
            // Application
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductQuery, ProductQuery>();

            return services;
        }
    }
}
