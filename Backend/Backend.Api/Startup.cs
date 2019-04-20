using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicStore.Backend.Infrastructure;
using MusicStore.Backend.Infrastructure.Foundation;

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
