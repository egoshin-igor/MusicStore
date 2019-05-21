using System.Threading.Tasks;
using MusicStore.Bank.Core.Clients;
using MusicStore.Lib.Repositories.Abstractions;

namespace MusicStore.Bank.Application.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> GetByIdAsync( string email );
        Task<Client> GetOwner();
    }
}
