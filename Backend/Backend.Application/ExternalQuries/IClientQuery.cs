using System.Threading.Tasks;

namespace MusicStore.Backend.Application.ExternalQuries
{
    public interface IClientQuery
    {
        Task<decimal?> GetBalanceAsync( string email );
    }
}
