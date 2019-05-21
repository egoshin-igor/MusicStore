using System.Collections.Generic;

namespace MusicStore.Backend.Api.Dtos
{
    public class BuyTransactionDto
    {
        public List<ProductToBuyDto> ProductsToBuy { get; set; }
    }
}
