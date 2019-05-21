using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Bank.Application.Queries;

namespace MusicStore.Bank.Api.Controllers
{
    [ApiController]
    [Route( "api/client" )]
    public class ClientController
    {
        private readonly IClientQuery _clientQuery;

        public ClientController( IClientQuery clientQuery )
        {
            _clientQuery = clientQuery;
        }

        [HttpGet, Route( "balance" )]
        public async Task<decimal?> GetBalance( [FromQuery] string email )
        {
            if ( email == null )
                return null;

            return await _clientQuery.GetBalanceAsync( email );
        }
    }
}
