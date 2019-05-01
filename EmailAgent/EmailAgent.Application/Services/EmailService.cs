using System.Threading.Tasks;

namespace MusicStore.EmailAgent.Application.Services
{
    public interface IEmailService
    {
        Task SendAsync( string to, string subject, string message );
    }
}
