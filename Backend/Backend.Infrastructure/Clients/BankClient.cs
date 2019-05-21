using System.Net.Http;
using MusicStore.Backend.Infrastructure.Settings;
using MusicStore.Lib.Http.Client;

namespace MusicStore.Backend.Infrastructure.Clients
{
    public class BankClient : BaseClient
    {
        public BankClient( HttpClient client, BackendAppSettings settings )
            : base( client, settings.BankApi )
        {
        }
    }
}
