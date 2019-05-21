using System;
using System.Threading.Tasks;
using MusicStore.Bank.Application.IntegrationEvents;
using MusicStore.Bank.Application.Repositories;
using MusicStore.Bank.Core.Clients;
using MusicStore.Lib.IntegrationEvents;

namespace MusicStore.Bank.Application.IntegrationEventHandlers
{
    public class TransferToOwnerRequestedAsyncHandler : IntegrationEventAsyncHandler<TransferToOwnerRequested>
    {
        private readonly IEventBus _eventBus;
        private readonly IClientRepository _clientRepository;

        public TransferToOwnerRequestedAsyncHandler( IEventBus eventBus, IClientRepository clientRepository )
        {
            _eventBus = eventBus;
            _clientRepository = clientRepository;
        }

        public async override Task HandleAsync( TransferToOwnerRequested @event )
        {
            Client owner = await _clientRepository.GetOwner();
            if ( owner == null )
                throw new ApplicationException( "Bank owner not found" );

            _eventBus.Publish( new TransferTransactionRequested
            {
                From = @event.From,
                Sum = @event.Sum,
                To = owner.Email,
                TransactionId = @event.TransactionId
            } );
        }
    }
}
