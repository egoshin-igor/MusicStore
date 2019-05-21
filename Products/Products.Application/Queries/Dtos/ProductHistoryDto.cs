using System;

namespace MusicStore.Products.Application.Queries.Dtos
{
    public class ProductHistoryDto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerItem { get; set; }
        public DateTime OccuredOnUtc { get; set; }
        public string TransactionId { get; set; }
    }
}
