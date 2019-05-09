using System;

namespace MusicStore.Backend.Application.Queries.Dtos
{
    public class UserLoginTokenDto
    {
        public string Token { get; set; }
        public DateTime ExpiratedOnUtc { get; set; }
    }
}
