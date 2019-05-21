using System.Threading.Tasks;

namespace MusicStore.Bank.Application.Queries
{
    public interface ITransactionsHistoryQuery
    {
        Task<bool> IsSuccessTransactionAsync( string transactionId );
    }
}
