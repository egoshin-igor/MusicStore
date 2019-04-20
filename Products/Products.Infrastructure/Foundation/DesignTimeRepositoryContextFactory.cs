using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MusicStore.Products.Infrastructure.Foundation
{
    public class DesignTimeRepositoryContextFactory :
        IDesignTimeDbContextFactory<ProductsDbContext>
    {
        public ProductsDbContext CreateDbContext( string[] args )
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath( Directory.GetCurrentDirectory() )
                .AddJsonFile( "appsettings.json" )
                .AddJsonFile( $"appsettings.{Environment.GetEnvironmentVariable( "ASPNETCORE_ENVIRONMENT" )}.json", true )
                .AddEnvironmentVariables();

            var config = builder.Build();
            var connectionString = config.GetConnectionString( "ProductsConnection" );
            var optionsBuilder = new DbContextOptionsBuilder<ProductsDbContext>();
            optionsBuilder.UseSqlServer( connectionString, x => x.MigrationsAssembly( "MusicStore.Products.Api" ) );

            return new ProductsDbContext( optionsBuilder.Options );
        }
    }
}
