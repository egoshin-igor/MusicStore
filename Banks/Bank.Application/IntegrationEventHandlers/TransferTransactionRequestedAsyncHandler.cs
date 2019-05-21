using System.Threading.Tasks;
using MusicStore.Bank.Application.IntegrationEvents;
using MusicStore.Bank.Application.Repositories;
using MusicStore.Bank.Core.Clients;
using MusicStore.Bank.Core.Types;
using MusicStore.Lib.IntegrationEvents;
using MusicStore.Lib.Repositories.Abstractions;

namespace MusicStore.Bank.Application.IntegrationEventHandlers
{
    public class TransferTransactionRequestedAsyncHandler : IntegrationEventAsyncHandler<TransferTransactionRequested>
    {
        private readonly IClientRepository _clientRepository;
        private readonly ITransactionsHistoryRepository _transactionsHistoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TransferTransactionRequestedAsyncHandler(
            IClientRepository clientRepository,
            ITransactionsHistoryRepository transactionsHistoryRepository,
            IUnitOfWork unitOfWork )
        {
            _clientRepository = clientRepository;
            _transactionsHistoryRepository = transactionsHistoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async override Task HandleAsync( TransferTransactionRequested @event )
        {
            Client fromClient = await _clientRepository.GetByIdAsync( @event.From );
            Client toClient = await _clientRepository.GetByIdAsync( @event.To );
            if ( fromClient == null || toClient == null )
                return;

            bool isSubstractedFrom = fromClient.UpdateBalance( -@event.Sum );
            bool isAddedTo = false;
            if ( isSubstractedFrom )
            {
                isAddedTo = toClient.UpdateBalance( @event.Sum );
            }
            bool isSuccess = isSubstractedFrom && isAddedTo;

            await _transactionsHistoryRepository.AddAsync( new TransactionsHistory(
                transactionId: @event.TransactionId,
                email: @event.From,
                isSuccess: isSuccess,
                transactionType: TransactionType.Transefering
            ) );

            await _unitOfWork.CommitAsync();
        }
    }
}
