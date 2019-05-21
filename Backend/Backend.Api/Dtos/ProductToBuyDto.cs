namespace MusicStore.Backend.Api.Dtos
{
    public class ProductToBuyDto
    {
        public int Id { get; set; }
        public decimal PricePerItem { get; set; }
        public int Quantity { get; set; }
    }
}
