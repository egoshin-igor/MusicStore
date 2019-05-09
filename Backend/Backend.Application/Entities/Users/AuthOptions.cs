using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MusicStore.Backend.Application.Entities.Users
{
    public class AuthOptions
    {
        const string Key = "my_very_secret_which_is_not_secret";   // ключ для шифрации

        public const string Issuer = "MusicStore";
        public const string Audience = "MusicStore";
        public const int LifeTimeInDays = 200;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey( Encoding.ASCII.GetBytes( Key ) );
        }
    }
}
