using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MusicStore.Backend.Infrastructure.Foundation;

namespace MusicStore.Products.Infrastructure.Foundation
{
    public class DesignTimeRepositoryContextFactory : IDesignTimeDbContextFactory<BackendDbContext>
    {
        public BackendDbContext CreateDbContext( string[] args )
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath( Directory.GetCurrentDirectory() )
                .AddJsonFile( "appsettings.json" )
                .AddJsonFile( $"appsettings.{Environment.GetEnvironmentVariable( "ASPNETCORE_ENVIRONMENT" )}.json", true )
                .AddEnvironmentVariables();

            var config = builder.Build();
            var connectionString = config.GetConnectionString( "BackendConnection" );
            var optionsBuilder = new DbContextOptionsBuilder<BackendDbContext>();
            optionsBuilder.UseSqlServer( connectionString, x => x.MigrationsAssembly( "MusicStore.Backend.Api" ) );

            return new BackendDbContext( optionsBuilder.Options );
        }
    }
}
