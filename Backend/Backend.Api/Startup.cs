using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicStore.Backend.Infrastructure;
using MusicStore.Backend.Infrastructure.Foundation;
using MusicStore.Products.Infrastructure.Foundation;

namespace MusicStore.Backend.Api
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
                .BuildBackendApllication()
                .AddMvc()
                .SetCompatibilityVersion( CompatibilityVersion.Version_2_2 );

            services.AddSingleton( Configuration.GetSection( "BackendAppSettings" ).Get<BackendAppSettings>() );
            services.AddDbContext<BackendDbContext>( c =>
                c.UseSqlServer( Configuration.GetConnectionString( "BackendConnection" ) ) );
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
