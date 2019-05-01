using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using MusicStore.EmailAgent.Application.Services;
using MusicStore.EmailAgent.Infrastructure.Settings;

namespace MusicStore.EmailAgent.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        EmailServiceSettings _emailServiceSettings;

        public EmailService( EmailServiceSettings emailServiceSettings )
        {
            _emailServiceSettings = emailServiceSettings;
        }

        public async Task SendAsync( string to, string subject, string message )
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add( new MailboxAddress( _emailServiceSettings.Sender.Name, _emailServiceSettings.Sender.Email ) );
            emailMessage.To.Add( new MailboxAddress( "", to ) );
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart( MimeKit.Text.TextFormat.Html )
            {
                Text = message
            };

            using ( var client = new SmtpClient() )
            {
                await client.ConnectAsync( _emailServiceSettings.SmtpServerAdress, _emailServiceSettings.SmtpServerPort, _emailServiceSettings.IsNeedToUseSsl );
                await client.AuthenticateAsync( _emailServiceSettings.Sender.Login, _emailServiceSettings.Sender.Password );
                await client.SendAsync( emailMessage );

                await client.DisconnectAsync( true );
            }
        }
    }
}
