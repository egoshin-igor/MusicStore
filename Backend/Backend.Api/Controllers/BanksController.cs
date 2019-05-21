using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Backend.Api.Dtos;
using MusicStore.Backend.Application.AppServices;
using MusicStore.Backend.Application.ExternalQuries;

namespace MusicStore.Backend.Api.Controllers
{
    [Route( "api/bank" )]
    [ApiController]
    [Authorize]
    public class BanksController : JsonController
    {
        private readonly IBankTransactionsService _bankTransactionsService;
        private readonly IClientQuery _clientQuery;

        public BanksController( IBankTransactionsService bankTransactionsService, IClientQuery clientQuery )
        {
            _bankTransactionsService = bankTransactionsService;
            _clientQuery = clientQuery;
        }

        [HttpGet, Route( "balance" )]
        public async Task<ClientBalanceDto> GetBalanceAsync()
        {
            decimal? balance = await _clientQuery.GetBalanceAsync( Email );

            return new ClientBalanceDto { Balance = balance ?? 0m };
        }

        [HttpPost, Route( "add" )]
        public async Task<IActionResult> AddAsync( [FromBody] AddTransactionDto addTransaction )
        {
            if ( addTransaction == null || addTransaction.Sum <= 0 )
                return new BadRequestResult();

            System.Console.WriteLine( Email );

            bool isSuccess = await _bankTransactionsService.ChangeAsync( Email, addTransaction.Sum );
            if ( !isSuccess )
                return new ConflictResult();

            return new OkResult();
        }

        [HttpPost, Route( "transfer" )]
        public async Task<IActionResult> TransferAsync( [FromBody] TransferTransactionDto transferTransaction )
        {
            if ( transferTransaction == null || string.IsNullOrWhiteSpace( transferTransaction.Email ) || transferTransaction.Sum <= 0 )
                return new BadRequestResult();

            bool isSuccess = await _bankTransactionsService.Transfer( Email, transferTransaction.Email, transferTransaction.Sum );
            if ( !isSuccess )
                return new ConflictResult();

            return new OkResult();
        }
    }
}
