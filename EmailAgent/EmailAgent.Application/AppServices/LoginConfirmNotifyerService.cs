using System;
using System.Threading.Tasks;
using MusicStore.EmailAgent.Application.Services;

namespace MusicStore.EmailAgent.Application.AppServices
{
    public interface ILoginConfirmNotifyerService
    {
        Task NotifyAsync( string email, string loginToken );
    }

    public class LoginConfirmNotifyerService : ILoginConfirmNotifyerService
    {
        private readonly IEmailService _emailService;

        public LoginConfirmNotifyerService( IEmailService emailService )
        {
            _emailService = emailService;
        }

        public async Task NotifyAsync( string email, string loginToken )
        {
            const string subject = "Авторизация аккаунта";
            string messageBody = "<p>Для того чтобы зайти в аккаунт, пожалуйста, перейдите по ссылке:</p>" +
                $"<a href=\"musicstore://confirm?loginToken={loginToken}\">Confirm</a>";

            int retryCount = 3;
            for ( int i = 0; i < retryCount; i++ )
            {
                try
                {
                    await _emailService.SendAsync( email, subject, messageBody );
                    break;
                }
                catch ( Exception ex )
                {
                    Console.WriteLine( ex.Message );
                }
            }

        }
    }
}
