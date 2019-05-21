using System.Threading.Tasks;
using MusicStore.Backend.Application.ExternalQuries;
using MusicStore.Backend.Infrastructure.Clients;
using MusicStore.Lib.Http.Client;

namespace MusicStore.Backend.Infrastructure.ExternalQueries
{
    public class ClientQuery : IClientQuery
    {
        private readonly BankClient _bankClient;

        protected ClientQuery()
        {
        }

        public ClientQuery( BankClient bankClient )
        {
            _bankClient = bankClient;
        }

        public async Task<decimal?> GetBalanceAsync( string email )
        {
            Response<decimal?> response = await _bankClient.GetAsync<decimal?>( $"api/client/balance?email={email}" );

            return response.Result;
        }
    }
}
