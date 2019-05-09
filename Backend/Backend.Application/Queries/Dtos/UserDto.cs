namespace MusicStore.Backend.Application.Queries.Dtos
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public UserLoginTokenDto LoginToken { get; set; }
    }
}
