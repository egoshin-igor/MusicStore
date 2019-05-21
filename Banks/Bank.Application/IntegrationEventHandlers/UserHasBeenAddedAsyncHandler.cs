using System.Threading.Tasks;
using MusicStore.Bank.Application.IntegrationEvents;
using MusicStore.Bank.Application.Repositories;
using MusicStore.Bank.Core.Clients;
using MusicStore.Lib.IntegrationEvents;
using MusicStore.Lib.Repositories.Abstractions;

namespace MusicStore.Bank.Application.IntegrationEventHandlers
{
    public class UserHasBeenAddedAsyncHandler : IntegrationEventAsyncHandler<UserHasBeenAdded>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserHasBeenAddedAsyncHandler( IClientRepository clientRepository, IUnitOfWork unitOfWork )
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        public async override Task HandleAsync( UserHasBeenAdded @event )
        {
            Client client = await _clientRepository.GetByIdAsync( @event.Email );
            if ( client != null )
                return;

            await _clientRepository.AddAsync( new Client( @event.Email ) );
            await _unitOfWork.CommitAsync();
        }
    }
}
