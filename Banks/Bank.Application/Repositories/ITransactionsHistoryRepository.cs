using MusicStore.Bank.Core.Clients;
using MusicStore.Lib.Repositories.Abstractions;

namespace MusicStore.Bank.Application.Repositories
{
    public interface ITransactionsHistoryRepository : IRepository<TransactionsHistory>
    {
    }
}
