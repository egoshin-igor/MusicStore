namespace MusicStore.Products.Core.Dtos
{
    public class ProductInfo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int? Quantity { get; set; }
        public string ImagePath { get; protected set; }
    }
}
