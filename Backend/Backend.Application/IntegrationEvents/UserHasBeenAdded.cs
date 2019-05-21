using MusicStore.Lib.IntegrationEvents;

namespace MusicStore.Backend.Application.IntegrationEvents
{
    public class UserHasBeenAdded : IntegrationEvent
    {
        public string Email { get; set; }
    }
}
