using System.Threading.Tasks;
using EventManagement.Domain.Commands;
using EventManagement.Domain.Responses;

namespace EventManagement.Domain.Interfaces.Transactions
{
    public interface ICreateCoffeePlaceTransaction
    {
        Task<CoffeePlaceResponse> Execute(CreateCoffeePlaceCommand command);
    }
}