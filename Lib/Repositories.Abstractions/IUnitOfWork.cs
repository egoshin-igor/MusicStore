using System.Threading.Tasks;

namespace MusicStore.Lib.Repositories.Abstractions
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}
