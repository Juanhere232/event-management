using EventManagement.Domain.Commands;
using EventManagement.Domain.Interfaces.Transactions;
using EventManagement.Domain.Interfaces.UnitOfWork;
using EventManagement.Domain.Responses;
using System.Threading.Tasks;
using EventManagement.Domain.Interfaces.Services;

namespace EventManagement.Domain.Transactions
{
    public class CreateEventRoomPlaceTransaction : TransactionBase, ICreateEventRoomPlaceTransaction
    {
        private readonly IEventRoomService _eventRoomService;

        public CreateEventRoomPlaceTransaction(
            IUnitOfWork unitOfWork,
            IEventRoomService eventRoomService)
            : base(unitOfWork)
        {
            _eventRoomService = eventRoomService;
        }

        public async Task<EventRoomResponse> Execute(CreateEventRoomCommand command)
        {
            var eventRoom = await _eventRoomService
                .Create(command);

            await Commit();

            return new EventRoomResponse(eventRoom);
        }
    }
}