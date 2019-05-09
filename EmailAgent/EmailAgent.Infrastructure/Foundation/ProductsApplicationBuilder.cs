using Microsoft.Extensions.DependencyInjection;
using MusicStore.EmailAgent.Application.AppServices;
using MusicStore.EmailAgent.Application.IntegrationEventHandlers;
using MusicStore.EmailAgent.Application.Services;

namespace MusicStore.EmailAgent.Infrastructure.Services
{
    public static class EmailAgentApplicationBuilder
    {
        public static IServiceCollection BuildEmailAgentApllication( this IServiceCollection services )
        {
            // AppServices
            services.AddScoped<ILoginConfirmNotifyerService, LoginConfirmNotifyerService>();

            // Services
            services.AddScoped<IEmailService, EmailService>();


            // Events
            services.AddScoped<UserAuthenticatedAsyncHandler>();

            return services;
        }
    }
}
