using System;
using System.Threading;
using System.Threading.Tasks;
using MusicStore.Backend.Application.ExternalQuries;
using MusicStore.Backend.Application.IntegrationEvents;
using MusicStore.Lib.IntegrationEvents;

namespace MusicStore.Backend.Application.AppServices
{
    public interface IBankTransactionsService
    {
        Task<bool> ChangeAsync( string email, decimal changeCount );
        Task<bool> Transfer( string from, string to, decimal sum );
    }

    public class BankTransactionsService : IBankTransactionsService
    {
        private readonly IEventBus _eventBus;
        private readonly ITransactionsHistoryQuery _transactionsHistoryQuery;

        public BankTransactionsService( IEventBus eventBus, ITransactionsHistoryQuery transactionsHistoryQuery )
        {
            _eventBus = eventBus;
            _transactionsHistoryQuery = transactionsHistoryQuery;
        }

        public async Task<bool> ChangeAsync( string email, decimal changeCount )
        {
            string transactionId = Guid.NewGuid().ToString();
            _eventBus.Publish( new ChangeClientBalanceRequested { Email = email, ChangeCount = changeCount, TransactionId = transactionId } );

            return await IsSuccessTransactonAsync( transactionId );
        }

        public async Task<bool> Transfer( string from, string to, decimal sum )
        {
            string transactionId = Guid.NewGuid().ToString();

            _eventBus.Publish( new TransferTransactionRequested
            {
                From = from,
                To = to,
                Sum = sum,
                TransactionId = transactionId
            } );

            return await IsSuccessTransactonAsync( transactionId );
        }

        private async Task<bool> IsSuccessTransactonAsync( string transactionId )
        {
            var result = false;

            int retryCount = 5;
            for ( int i = 0; i < retryCount; i++ )
            {
                if ( await _transactionsHistoryQuery.IsSuccessTransaction( transactionId ) )
                {
                    result = true;
                    break;
                }

                Thread.Sleep( 300 );
            }

            return result;
        }
    }
}
