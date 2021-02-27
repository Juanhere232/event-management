using EventManagement.Domain.Commands;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Interfaces.Repositories;
using EventManagement.Domain.Interfaces.Services;
using EventManagement.Domain.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Domain.Services
{
    public class EventRoomService : IEventRoomService
    {
        private readonly IEventRoomRepository _eventRoomRepository;

        public EventRoomService(IEventRoomRepository eventRoomRepository)
        {
            _eventRoomRepository = eventRoomRepository;
        }

        public async Task<IList<EventRoomResponse>> GetAll()
        {
            var eventRooms = await _eventRoomRepository
                .GetAllAsync();

            return eventRooms
                .Select(eventRoom => new EventRoomResponse(eventRoom))
                .ToList();
        }

        public async Task<EventRoomWithDetailsResponse> GetByIdWithDetails(long id)
        {
            var coffeePlace = await _eventRoomRepository
                .GetByIdAsync(id);

            return new EventRoomWithDetailsResponse(coffeePlace);
        }

        public async Task<EventRoom> Create(CreateEventRoomCommand command)
        {
            var eventRoom = new EventRoom(command);

            await _eventRoomRepository
                .AddAsync(eventRoom);

            return eventRoom;
        }

        public async Task<EventRoom> Update(UpdateEventRoomCommand command)
        {
            var eventRoom = await _eventRoomRepository
                .GetByIdAsync(command.EventRoomId);

            if (eventRoom == null)
                throw new NotFoundException("Sala de Evento não encontrada");

            eventRoom.Update(command);

            return eventRoom;
        }
    }
}