using MusicStore.Products.Core.Dtos;

namespace MusicStore.Products.Core.Products
{
    public class Product
    {
        public int Id { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public string Category { get; protected set; }
        public int Quantity { get; protected set; }
        public string ImagePath { get; protected set; }
        public decimal Price { get; protected set; }

        protected Product()
        {
        }

        public Product( ProductInfo productInfo )
        {
            Update( productInfo );
        }

        public void ChangeQuantity( int count )
        {
            Quantity += count;
        }

        public void Update( ProductInfo productInfo )
        {
            if ( productInfo.Title != null )
            {
                Title = productInfo.Title;
            }
            if ( productInfo.Description != null )
            {
                Description = productInfo.Description;
            }
            if ( productInfo.Category != null )
            {
                Category = productInfo.Category;
            }
            if ( productInfo.Quantity != null )
            {
                Quantity = productInfo.Quantity.Value;
            }
            if ( productInfo.ImagePath != null )
            {
                ImagePath = productInfo.ImagePath;
            }
            if ( productInfo.Price != null )
            {
                Price = productInfo.Price.Value;
            }
        }
    }
}
