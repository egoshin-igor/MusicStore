using MusicStore.Lib.IntegrationEvents;

namespace MusicStore.Bank.Application.IntegrationEvents
{
    public class ChangeClientBalanceRequested : IntegrationEvent
    {
        public string TransactionId { get; set; }
        public string Email { get; set; }
        public decimal ChangeCount { get; set; }
    }
}
