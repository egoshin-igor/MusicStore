using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Bank.Application.Repositories;
using MusicStore.Bank.Core.Clients;
using MusicStore.Banks.Infrastructure.Foundation;
using MusicStore.Lib.Repositories;

namespace MusicStore.Bank.Infrastructure.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository( BanksDbContext dbContext ) : base( dbContext )
        {
        }

        public async Task<Client> GetByIdAsync( string email )
        {
            return await Entities.FirstOrDefaultAsync( e => e.Email == email );
        }

        public async Task<Client> GetOwner()
        {
            const string ownerEmail = "igor.egoshin@mail.ru";

            return await Entities.FirstOrDefaultAsync( e => e.Email == ownerEmail );

        }
    }
}
