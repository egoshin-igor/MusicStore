using Microsoft.Extensions.DependencyInjection;
using MusicStore.EmailAgent.Application.Services;

namespace MusicStore.EmailAgent.Infrastructure.Services
{
    public static class EmailAgentApplicationBuilder
    {
        public static IServiceCollection BuildEmailAgentApllication( this IServiceCollection services )
        {
            // Application
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
