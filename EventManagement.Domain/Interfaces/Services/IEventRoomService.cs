using EventManagement.Domain.Commands;
using EventManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagement.Domain.Responses;

namespace EventManagement.Domain.Interfaces.Services
{
    public interface IEventRoomService
    {
        Task<IList<EventRoomResponse>> GetAll();
        Task<EventRoomWithDetailsResponse> GetByIdWithDetails(long id);
        Task<EventRoom> Create(CreateEventRoomCommand command);
        Task<EventRoom> Update(UpdateEventRoomCommand command);
    }
}