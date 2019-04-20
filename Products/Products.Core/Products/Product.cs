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

        public Product(
            string title,
            string description,
            string category,
            int quantity,
            string imagePath )
        {
            Title = title;
            Description = description;
            Category = category;
            Quantity = quantity;
            ImagePath = imagePath;
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
        }
    }
}
