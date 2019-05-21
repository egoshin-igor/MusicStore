using System.Net.Http;
using MusicStore.Backend.Application.Clients;
using MusicStore.Backend.Infrastructure.Settings;
using MusicStore.Lib.Http.Client;

namespace MusicStore.Backend.Infrastructure.Clients
{
    public class ProductClient : BaseClient, IProductClient
    {
        public ProductClient( HttpClient client, BackendAppSettings settings )
            : base( client, settings.ProductsApi )
        {
        }
    }
}
