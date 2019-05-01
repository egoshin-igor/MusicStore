using System;

namespace MusicStore.Backend.Application.Entities.Users
{
    public class UserLoginToken
    {
        public string Email { get; protected set; }
        public string Token { get; protected set; }
        public DateTime ExpiratedOnUtc { get; protected set; }

        public UserLoginToken( string email, string token, DateTime expiratedOnUtc )
        {
            Email = email;
            Token = token;
            ExpiratedOnUtc = ExpiratedOnUtc;
        }
    }
}
