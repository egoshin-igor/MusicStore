using MusicStore.Lib.IntegrationEvents;

namespace MusicStore.Products.Application.IntegrationEvents
{
    public class ReserveMoneyRequested : IntegrationEvent
    {
        public decimal MoneyQunatity { get; set; }
        public string Email { get; set; }
    }
}
