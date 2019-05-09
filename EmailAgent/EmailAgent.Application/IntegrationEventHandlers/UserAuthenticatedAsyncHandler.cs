using System;
using System.Threading.Tasks;
using MusicStore.EmailAgent.Application.AppServices;
using MusicStore.EmailAgent.Application.IntegrationEvents;
using MusicStore.Lib.IntegrationEvents;

namespace MusicStore.EmailAgent.Application.IntegrationEventHandlers
{
    public class UserAuthenticatedAsyncHandler : IntegrationEventAsyncHandler<UserAuthenticated>
    {
        private readonly ILoginConfirmNotifyerService _loginConfirmNotifyerService;

        public UserAuthenticatedAsyncHandler( ILoginConfirmNotifyerService loginConfirmNotifyerService )
        {
            _loginConfirmNotifyerService = loginConfirmNotifyerService;
        }

        public override async Task HandleAsync( UserAuthenticated @event )
        {
            await _loginConfirmNotifyerService.NotifyAsync( @event.Email, @event.LoginToken );
        }
    }
}
