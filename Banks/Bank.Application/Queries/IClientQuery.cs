using System.Threading.Tasks;

namespace MusicStore.Bank.Application.Queries
{
    public interface IClientQuery
    {
        Task<decimal?> GetBalanceAsync( string email );
    }
}
