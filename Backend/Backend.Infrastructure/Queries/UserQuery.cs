using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Backend.Application.Entities.Users;
using MusicStore.Backend.Application.Queries;
using MusicStore.Backend.Application.Queries.Dtos;
using MusicStore.Backend.Infrastructure.Foundation;
using MusicStore.Lib.Queries.Abstractions;

namespace MusicStore.Backend.Infrastructure.Queries
{
    public class UserQuery : BaseQuery<User>, IUserQuery
    {
        public UserQuery( BackendDbContext dbContext ) : base( dbContext )
        {
        }
    }
}
