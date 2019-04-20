using System.Net.Http;
using MusicStore.Lib.Http.Client;

namespace MusicStore.Backend.Infrastructure.Clients
{
    public class ProductClient : BaseClient
    {
        public ProductClient( HttpClient client, BackendAppSettings settings )
            : base( client, settings.ProductsApi )
        {
        }
    }
}
