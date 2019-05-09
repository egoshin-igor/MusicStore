using System.Threading.Tasks;

namespace MusicStore.Lib.Bus.Abstractions
{
    public interface IBusMessageAsyncHandler<T> where T : IBusMessage
    {
        Task HandleAsync( T busMessage );
    }
}
