using System.Threading.Tasks;
using MusicStore.Backend.Application.ExternalQuries;
using MusicStore.Backend.Infrastructure.Clients;
using MusicStore.Lib.Http.Client;

namespace MusicStore.Backend.Infrastructure.ExternalQueries
{
    public class TransactionsHistoryQuery : ITransactionsHistoryQuery
    {
        private readonly BankClient _bankClient;

        public TransactionsHistoryQuery( BankClient bankClient )
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
