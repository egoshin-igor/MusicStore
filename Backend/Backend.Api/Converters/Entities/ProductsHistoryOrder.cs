using System.Collections.Generic;

namespace MusicStore.Backend.Api.Converters.Entities
{
    public class ProductsHistoryOrder
    {
        public string OccuredOnUtc { get; set; }
        public List<ProductHistoryOrderItem> Items { get; set; }
    }
}
