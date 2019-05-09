using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Backend.Application.AppServices;
using MusicStore.Backend.Application.AppServices.Entities;
using MusicStore.Backend.Application.BaseEntity;
using MusicStore.Lib.Repositories.Abstractions;

namespace MusicStore.Backend.Api.Controllers
{
    [Route( "api/account" )]
    [ApiController]
    public class AccountController : JsonController
    {
        private readonly IAccountService _accountService;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController( IAccountService accountService, IUnitOfWork unitOfWork )
        {
            _accountService = accountService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost, Route( "auth" )]
        public async Task<JsonResponse> Auth( [FromBody] string email )
        {
            await _accountService.AuthenticateAsync( email );
            await _unitOfWork.CommitAsync();

            return Success();
        }

        [HttpPost, Route( "confirm" )]
        public async Task<IActionResult> ConfirmAsync( [FromQuery] string email, [FromQuery] string loginToken )
        {
            ConfirmResult result = await _accountService.ConfirmAsync( email, loginToken );
            if ( result == null )
            {
                return BadRequest();
            }

            return Ok( result );
        }
    }
}
