using System.Threading.Tasks;
using MusicStore.Bank.Application.IntegrationEvents;
using MusicStore.Bank.Application.Repositories;
using MusicStore.Bank.Core.Clients;
using MusicStore.Bank.Core.Types;
using MusicStore.Lib.IntegrationEvents;
using MusicStore.Lib.Repositories.Abstractions;

namespace MusicStore.Bank.Application.IntegrationEventHandlers
{
    public class ChangeClientBalanceRequestedAsyncHandler : IntegrationEventAsyncHandler<ChangeClientBalanceRequested>
    {
        private readonly IClientRepository _clientRepository;
        private readonly ITransactionsHistoryRepository _transactionsHistoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ChangeClientBalanceRequestedAsyncHandler(
            IClientRepository clientRepository,
            ITransactionsHistoryRepository transactionsHistoryRepository,
            IUnitOfWork unitOfWork )
        {
            _clientRepository = clientRepository;
            _transactionsHistoryRepository = transactionsHistoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async override Task HandleAsync( ChangeClientBalanceRequested @event )
        {
            Client client = await _clientRepository.GetByIdAsync( @event.Email );
            if ( client == null )
                return;

            bool isSuccess = client.UpdateBalance( @event.ChangeCount );
            await _transactionsHistoryRepository.AddAsync( new TransactionsHistory(
                transactionId: @event.TransactionId,
                email: @event.Email,
                isSuccess: isSuccess,
                transactionType: TransactionType.Updating
            ) );

            await _unitOfWork.CommitAsync();
        }
    }
}
