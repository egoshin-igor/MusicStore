using System.Collections.Generic;

namespace MusicStore.Products.Api.Dtos
{
    public class BuyTransactionDto
    {
        public List<ProductToBuyDto> ProductsToBuy { get; set; }
        public string Email { get; set; }
    }
}
