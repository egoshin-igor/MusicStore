using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Bank.Application.Queries;

namespace MusicStore.Bank.Api.Controllers
{
    [ApiController]
    [Route( "api/transactions-history" )]
    public class TransactionHistoryController
    {
        private readonly ITransactionsHistoryQuery _transactionsHistoryQuery;

        public TransactionHistoryController( ITransactionsHistoryQuery transactionsHistoryQuery )
        {
            _transactionsHistoryQuery = transactionsHistoryQuery;
        }

        [HttpGet, Route( "is-success" )]
        public async Task<bool> IsSuccess( [FromQuery] string transactionId )
        {
            if ( transactionId == null )
                return false;

            return await _transactionsHistoryQuery.IsSuccessTransactionAsync( transactionId );
        }
    }
}
