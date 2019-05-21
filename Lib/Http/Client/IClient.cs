using System.Threading.Tasks;

namespace MusicStore.Lib.Http.Client
{
    public interface IClient
    {
        Task<Response<R>> PostAsync<R, D>( D data, string path );
        Task<Response<R>> GetAsync<R>( string url );
    }
}
