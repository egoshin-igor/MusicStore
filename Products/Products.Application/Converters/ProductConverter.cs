using MusicStore.Products.Application.IntegrationEvents.Dtos;
using MusicStore.Products.Core.Dtos;

namespace MusicStore.Products.Application.Converters
{
    public static class ProductConverter
    {
        public static ProductInfo DtoToInfo( ProductDto productDto )
        {
            return new ProductInfo
            {
                Category = productDto.Category,
                Description = productDto.Description,
                ImagePath = productDto.ImagePath,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
                Title = productDto.Title
            };
        }
    }
}
