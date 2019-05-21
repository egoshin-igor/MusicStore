using MusicStore.Bank.Application.Repositories;
using MusicStore.Bank.Core.Clients;
using MusicStore.Banks.Infrastructure.Foundation;
using MusicStore.Lib.Repositories;

namespace MusicStore.Bank.Infrastructure.Repositories
{
    public class TransactionsHistoryRepository : Repository<TransactionsHistory>, ITransactionsHistoryRepository
    {
        public TransactionsHistoryRepository( BanksDbContext dbContext ) : base( dbContext )
        {
        }
    }
}
