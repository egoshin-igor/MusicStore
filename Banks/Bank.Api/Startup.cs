using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicStore.Banks.Infrastructure.Foundation;
using MusicStore.Lib.IntegrationEvents;

namespace MusicStore.Bank.Api
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices( IServiceCollection services )
        {
            services
                .BuildBanksApllication()
                .AddEventBus()
                .AddMvc()
                .SetCompatibilityVersion( CompatibilityVersion.Version_2_2 );

            services.AddDbContext<BanksDbContext>( c =>
                c.UseSqlServer( Configuration.GetConnectionString( "BanksConnection" ) ) );

            services.BuildServiceProvider().EnableEventListeners();
        }

        public void Configure( IApplicationBuilder app, IHostingEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
