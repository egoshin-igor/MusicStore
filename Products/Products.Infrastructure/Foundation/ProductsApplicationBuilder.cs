using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicStore.Products.Application.BaseEntities;
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
