using MusicStore.Lib.IntegrationEvents;

namespace MusicStore.Bank.Application.IntegrationEvents
{
    public class UserHasBeenAdded : IntegrationEvent
    {
        public string Email { get; set; }
    }
}
