using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using MusicStore.Backend.Application.AppServices.Entities;
using MusicStore.Backend.Application.Entities.Users;
using MusicStore.Backend.Application.IntegrationEvents;
using MusicStore.Backend.Application.Repositories;
using MusicStore.Lib.IntegrationEvents;

namespace MusicStore.Backend.Application.AppServices
{
    public interface IAccountService
    {
        Task AuthenticateAsync( string email );
        Task<ConfirmResult> ConfirmAsync( string email, string loginToken );
    }

    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEventBus _eventBus;

        public AccountService( IUserRepository userRepository, IEventBus eventBus )
        {
            _userRepository = userRepository;
            _eventBus = eventBus;
        }

        public async Task AuthenticateAsync( string email )
        {
            string loginToken = Guid.NewGuid().ToString();

            var user = await _userRepository.GetAsync( email );
            if ( user == null )
            {
                user = new User( email, UserRole.User );
                _userRepository.Add( user );
                _eventBus.Publish( new UserHasBeenAdded { Email = email } );
            }
            user.UpdateLoginToken( loginToken );

            _eventBus.Publish( new UserAuthenticated { Email = email, LoginToken = loginToken } );
        }

        public async Task<ConfirmResult> ConfirmAsync( string email, string loginToken )
        {
            ClaimsIdentity identity = await GetIdentityAsync( email, loginToken );
            if ( identity == null )
                return null;

            var utcNow = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.Issuer,
                    audience: AuthOptions.Audience,
                    notBefore: utcNow,
                    claims: identity.Claims,
                    expires: utcNow.Add( TimeSpan.FromDays( AuthOptions.LifeTimeInDays ) ),
                    signingCredentials: new SigningCredentials( AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256 ) );
            string encodedJwt = new JwtSecurityTokenHandler().WriteToken( jwt );

            string userRole = identity.Claims.First( i => i.Type == ClaimsIdentity.DefaultRoleClaimType ).Value;
            return new ConfirmResult { AccessToken = encodedJwt, RefreshToken = "", UserRole = userRole };
        }

        private async Task<ClaimsIdentity> GetIdentityAsync( string email, string loginToken )
        {
            User user = await _userRepository.GetAsync( email );
            if ( user == null )
                return null;
            if ( !user.IsValidLoginToken( loginToken ) )
                return null;

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims,
                "Token",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType
            );

            return claimsIdentity;
        }
    }
}
