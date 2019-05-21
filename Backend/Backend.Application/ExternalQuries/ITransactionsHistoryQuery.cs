using System.Threading.Tasks;

namespace MusicStore.Backend.Application.ExternalQuries
{
    public interface ITransactionsHistoryQuery
    {
        Task<bool> IsSuccessTransaction( string transactionId );
    }
}
