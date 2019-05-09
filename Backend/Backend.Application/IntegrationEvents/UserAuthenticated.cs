using MusicStore.Lib.IntegrationEvents;

namespace MusicStore.Backend.Application.IntegrationEvents
{
    public class UserAuthenticated : IntegrationEvent
    {
        public string Email { get; set; }
        public string LoginToken { get; set; }
    }
}
