using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Bank.Application.Queries;
using MusicStore.Bank.Core.Clients;
using MusicStore.Banks.Infrastructure.Foundation;
using MusicStore.Lib.Queries.Abstractions;

namespace MusicStore.Bank.Infrastructure.Queries
{
    public class ClientQuery : BaseQuery<Client>, IClientQuery
    {
        public ClientQuery( BanksDbContext dbContext ) : base( dbContext )
        {
        }

        public async Task<decimal?> GetBalanceAsync( string email )
        {
            Client client = await Query.FirstOrDefaultAsync( q => q.Email == email );

            return client?.Balance;
        }
    }
}
