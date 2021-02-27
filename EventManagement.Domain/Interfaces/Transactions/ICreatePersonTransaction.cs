using EventManagement.Domain.Commands;
using EventManagement.Domain.Responses;
using System.Threading.Tasks;

namespace EventManagement.Domain.Interfaces.Transactions
{
    public interface ICreatePersonTransaction
    {
        Task<PersonWithDetailsResponse> Execute(CreatePersonCommand command);
    }
}