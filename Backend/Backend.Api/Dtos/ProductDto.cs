namespace MusicStore.Backend.Api.Dtos
{
    public class ProductDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int? Quantity { get; set; }
        public byte[] Image { get; set; }
        public decimal? Price { get; set; }
    }
}
