using MusicStore.Lib.IntegrationEvents;

namespace MusicStore.Backend.Application.IntegrationEvents
{
    public class ChangeClientBalanceRequested : IntegrationEvent
    {
        public string TransactionId { get; set; }
        public string Email { get; set; }
        public decimal ChangeCount { get; set; }
    }
}
