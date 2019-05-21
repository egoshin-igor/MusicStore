namespace MusicStore.Products.Application.AppServices.Entities
{
    public class ProductToBuy
    {
        public int Id { get; set; }
        public decimal PricePerItem { get; set; }
        public int Quantity { get; set; }
    }
}
