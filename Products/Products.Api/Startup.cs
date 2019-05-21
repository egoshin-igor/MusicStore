using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicStore.Lib.IntegrationEvents;
using MusicStore.Products.Application.Settings;
using MusicStore.Products.Infrastructure.Foundation;
using MusicStore.Products.Infrastructure.Settings;

namespace MusicStore.Products.Api
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            services
                .AddEventBus()
                .BuildProductsApllication()
                .AddMvc()
                .SetCompatibilityVersion( CompatibilityVersion.Version_2_2 );

            services.AddDbContext<ProductsDbContext>( c =>
                c.UseSqlServer( Configuration.GetConnectionString( "ProductsConnection" ) ) );
            services.AddSingleton( Configuration.GetSection( "StaticFilesPath" ).Get<StaticFilesPath>() );
            services.AddSingleton( Configuration.GetSection( "ProductsAppSettings" ).Get<ProductsAppSettings>() );

            services.BuildServiceProvider().EnableEventListeners();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
