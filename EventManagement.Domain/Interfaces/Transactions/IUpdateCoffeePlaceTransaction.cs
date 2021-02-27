using System.Threading.Tasks;
using EventManagement.Domain.Commands;
using EventManagement.Domain.Responses;

namespace EventManagement.Domain.Interfaces.Transactions
{
    public interface IUpdateCoffeePlaceTransaction
    {
        Task<CoffeePlaceResponse> Execute(UpdateCoffeePlaceCommand command);
    }
}