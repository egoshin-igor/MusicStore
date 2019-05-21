using System.Net.Http;
using MusicStore.Lib.Http.Client;
using MusicStore.Products.Infrastructure.Settings;

namespace MusicStore.Products.Infrastructure.Clients
{
    public interface IBankClient : IClient
    {
    }

    public class BankClient : BaseClient, IBankClient
    {
        public BankClient( HttpClient client, ProductsAppSettings productsAppSettings )
            : base( client, productsAppSettings.BankApi )
        {
        }
    }
}
