using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MusicStore.Banks.Infrastructure.Foundation
{
    public class DesignTimeRepositoryContextFactory : IDesignTimeDbContextFactory<BanksDbContext>
    {
        public BanksDbContext CreateDbContext( string[] args )
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath( Directory.GetCurrentDirectory() )
                .AddJsonFile( "appsettings.json" )
                .AddJsonFile( $"appsettings.{Environment.GetEnvironmentVariable( "ASPNETCORE_ENVIRONMENT" )}.json", true )
                .AddEnvironmentVariables();

            var config = builder.Build();
            var connectionString = config.GetConnectionString( "BanksConnection" );
            var optionsBuilder = new DbContextOptionsBuilder<BanksDbContext>();
            optionsBuilder.UseSqlServer( connectionString, x => x.MigrationsAssembly( "MusicStore.Bank.Api" ) );

            return new BanksDbContext( optionsBuilder.Options );
        }
    }
}
