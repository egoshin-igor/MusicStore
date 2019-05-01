using System;
using System.Linq.Expressions;

namespace MusicStore.Backend.Application.Entities.Users
{
    public partial class User
    {
        protected UserLoginToken _loginToken { get; set; }

        public string Email { get; protected set; }
        public string Role { get; protected set; }

        public User( string email, string role )
        {
            Email = email;
            Role = role;
        }

        public void UpdateLoginToken( string token )
        {
            var tokenExpirationDateOnUtc = DateTime.UtcNow.AddMinutes( 5 );
            _loginToken = new UserLoginToken( Email, token, tokenExpirationDateOnUtc );
        }

        public bool IsValidLoginToken( string token )
        {
            if ( _loginToken.Token != token )
                return false;

            if ( _loginToken.ExpiratedOnUtc < DateTime.UtcNow )
                return false;

            return true;
        }
    }

    public partial class User
    {
        public static Expression<Func<User, UserLoginToken>> LoginTokenProperty => u => u._loginToken;
    }
}
