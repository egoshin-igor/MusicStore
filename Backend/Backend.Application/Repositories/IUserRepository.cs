using System.Threading.Tasks;
using MusicStore.Backend.Application.Entities.Users;
using MusicStore.Lib.Repositories.Abstractions;

namespace MusicStore.Backend.Application.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetAsync( string email );
    }
}
