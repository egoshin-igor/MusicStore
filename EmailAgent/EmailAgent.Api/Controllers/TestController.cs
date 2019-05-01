using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicStore.EmailAgent.Application.Services;

namespace EmailAgent.Api.Controllers
{
    [Route( "api/test" )]
    [ApiController]
    public class TestController : ControllerBase
    {
        IEmailService _emailService;

        public TestController( IEmailService emailService )
        {
            _emailService = emailService;
        }

        [HttpGet, Route( "send" )]
        public async Task<string> SendAsync( [FromQuery] string to, [FromQuery] string subject, [FromQuery] string message )
        {
            await _emailService.SendAsync( to, subject, message );
            return "Ok";
        }
    }
}