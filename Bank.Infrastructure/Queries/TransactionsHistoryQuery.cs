using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Bank.Application.Queries;
using MusicStore.Bank.Core.Clients;
using MusicStore.Banks.Infrastructure.Foundation;
using MusicStore.Lib.Queries.Abstractions;

namespace MusicStore.Bank.Infrastructure.Queries
{
    public class TransactionsHistoryQuery : BaseQuery<TransactionsHistory>, ITransactionsHistoryQuery
    {
        public TransactionsHistoryQuery( BanksDbContext dbContext ) : base( dbContext )
        {
        }

        public async Task<bool> IsSuccessTransactionAsync( string transactionId )
        {
            TransactionsHistory transaction = await Query.FirstOrDefaultAsync( q => q.Id == transactionId );
            if ( transaction == null )
                return false;

            return transaction.IsSuccess;
        }
    }
}
