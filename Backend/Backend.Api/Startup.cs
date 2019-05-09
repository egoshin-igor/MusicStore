using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MusicStore.Backend.Application.Entities.Users;
using MusicStore.Backend.Infrastructure;
using MusicStore.Backend.Infrastructure.Foundation;
using MusicStore.Lib.IntegrationEvents;
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

        public void ConfigureServices( IServiceCollection services )
        {
            services
                .BuildBackendApllication()
                .AddEventBus()
                .AddMvc()
                .SetCompatibilityVersion( CompatibilityVersion.Version_2_2 );

            AddAuthentication( services );
            services.AddSingleton( Configuration.GetSection( "BackendAppSettings" ).Get<BackendAppSettings>() );
            services.AddDbContext<BackendDbContext>( c =>
                c.UseSqlServer( Configuration.GetConnectionString( "BackendConnection" ) ) );
        }

        public void Configure( IApplicationBuilder app, IHostingEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
        }

        private void AddAuthentication( IServiceCollection services )
        {
            services.AddAuthentication( JwtBearerDefaults.AuthenticationScheme )
                .AddJwtBearer( options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                } );
        }
    }
}
