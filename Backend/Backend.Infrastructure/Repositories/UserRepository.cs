using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Backend.Application.Entities.Users;
using MusicStore.Backend.Application.Repositories;
using MusicStore.Backend.Infrastructure.Foundation;
using MusicStore.Lib.Repositories;

namespace MusicStore.Backend.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository( BackendDbContext dbContext ) : base( dbContext )
        {
        }

        public async Task<User> GetAsync( string email )
        {
            return await Entities
                .Where( e => e.Email == email )
                .Include( User.LoginTokenProperty )
                .FirstOrDefaultAsync();
        }
    }
}
