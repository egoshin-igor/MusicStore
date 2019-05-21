using MusicStore.Lib.IntegrationEvents;

namespace MusicStore.Backend.Application.IntegrationEvents
{
    public class TransferTransactionRequested : IntegrationEvent
    {
        public string TransactionId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Sum { get; set; }
    }
}
