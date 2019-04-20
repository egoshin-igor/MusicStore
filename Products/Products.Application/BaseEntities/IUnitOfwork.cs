using System.Threading.Tasks;

namespace MusicStore.Products.Application.BaseEntities
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}
