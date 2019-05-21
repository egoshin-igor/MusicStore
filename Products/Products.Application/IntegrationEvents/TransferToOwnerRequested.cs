using MusicStore.Lib.IntegrationEvents;

namespace MusicStore.Products.Application.IntegrationEvents
{
    public class TransferToOwnerRequested : IntegrationEvent
    {
        public string From { get; set; }
        public decimal Sum { get; set; }
        public string TransactionId { get; set; }
    }
}
