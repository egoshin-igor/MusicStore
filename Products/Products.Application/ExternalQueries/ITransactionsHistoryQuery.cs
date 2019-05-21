using System.Threading.Tasks;

namespace MusicStore.Products.Application.ExternalQueries
{
    public interface ITransactionsHistoryQuery
    {
        Task<bool> IsSuccessTransaction( string transactionId );
    }
}
