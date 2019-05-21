namespace MusicStore.Backend.Api.Converters.Entities
{
    public class ProductHistoryOrderItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerItem { get; set; }
    }
}
