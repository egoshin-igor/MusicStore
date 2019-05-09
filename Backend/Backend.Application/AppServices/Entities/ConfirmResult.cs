namespace MusicStore.Backend.Application.AppServices.Entities
{
    public class ConfirmResult
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string UserRole { get; set; }
    }
}
