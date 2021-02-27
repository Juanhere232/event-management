using EventManagement.Domain.Commands;
using EventManagement.Domain.Responses;
using System.Threading.Tasks;

namespace EventManagement.Domain.Interfaces.Transactions
{
    public interface IUpdatePersonTransaction
    {
        Task<PersonWithDetailsResponse> Execute(UpdatePersonCommand command);
    }
}