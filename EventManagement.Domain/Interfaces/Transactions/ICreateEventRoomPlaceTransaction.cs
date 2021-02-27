using EventManagement.Domain.Commands;
using EventManagement.Domain.Responses;
using System.Threading.Tasks;

namespace EventManagement.Domain.Interfaces.Transactions
{
    public interface ICreateEventRoomPlaceTransaction
    {
        Task<EventRoomResponse> Execute(CreateEventRoomCommand command);
    }
}