using EventManagement.Domain.Commands;
using EventManagement.Domain.Responses;
using System.Threading.Tasks;

namespace EventManagement.Domain.Interfaces.Transactions
{
    public interface IUpdateEventRoomTransaction
    {
        Task<EventRoomResponse> Execute(UpdateEventRoomCommand command);
    }
}