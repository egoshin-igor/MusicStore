using System;

namespace MusicStore.Products.Core.Products
{
    public class ProductHistory
    {
        public int Id { get; protected set; }
        public string Email { get; protected set; }
        public string ProductName { get; protected set; }
        public int Qunatity { get; protected set; }
        public decimal PricePerItem { get; protected set; }
        public DateTime OccuredOnUtc { get; protected set; }
        public string TransactionId { get; protected set; }

        protected ProductHistory()
        {
        }

        public ProductHistory(
            string email,
            string productName,
            int quantity,
            decimal pricePerItem,
            DateTime occuredOnUtc,
            string transactionId )
        {
            Email = email;
            ProductName = productName;
            Qunatity = quantity;
            PricePerItem = pricePerItem;
            OccuredOnUtc = occuredOnUtc;
            TransactionId = transactionId;
        }
    }
}
