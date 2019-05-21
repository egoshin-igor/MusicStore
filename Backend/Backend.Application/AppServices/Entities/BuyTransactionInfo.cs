using System.Collections.Generic;

namespace MusicStore.Backend.Application.AppServices.Entities
{
    public class BuyTransactionInfo
    {
        public List<ProductToBuy> ProductsToBuy { get; set; }
        public string Email { get; set; }
    }
}
