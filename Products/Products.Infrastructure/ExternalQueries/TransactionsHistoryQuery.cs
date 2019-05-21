using System.Threading.Tasks;
using MusicStore.Lib.Http.Client;
using MusicStore.Products.Application.ExternalQueries;
using MusicStore.Products.Infrastructure.Clients;

namespace MusicStore.Products.Infrastructure.ExternalQueries
{
    public class TransactionsHistoryQuery : ITransactionsHistoryQuery
    {
        private readonly IBankClient _bankClient;

        public TransactionsHistoryQuery( IBankClient bankClient )
        {
            _bankClient = bankClient;
        }

        public async Task<bool> IsSuccessTransaction( string transactionId )
        {
            Response<bool> response = await _bankClient.GetAsync<bool>( $"api/transactions-history/is-success?transactionId={transactionId}" );

            return response.Result;
        }
    }
}
