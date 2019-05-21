using System.Collections.Generic;

namespace MusicStore.Backend.Api.Converters.Entities
{
    public class ProductsHistory
    {
        public List<ProductsHistoryOrder> Orders { get; set; }
    }
}
