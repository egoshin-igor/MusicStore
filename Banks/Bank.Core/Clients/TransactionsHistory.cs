using MusicStore.Bank.Core.Types;

namespace MusicStore.Bank.Core.Clients
{
    public class TransactionsHistory
    {
        public string Id { get; protected set; }
        public string Email { get; protected set; }
        public bool IsSuccess { get; protected set; }
        public TransactionType Type { get; protected set; }

        protected TransactionsHistory()
        {
        }

        public TransactionsHistory( string transactionId, string email, bool isSuccess, TransactionType transactionType )
        {
            Id = transactionId;
            Email = email;
            IsSuccess = isSuccess;
            Type = transactionType;
        }
    }
}
