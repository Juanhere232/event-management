using System.Threading.Tasks;
using EventManagement.Domain.Commands;
using EventManagement.Domain.Interfaces.Services;
using EventManagement.Domain.Interfaces.Transactions;
using EventManagement.Domain.Interfaces.UnitOfWork;
using EventManagement.Domain.Responses;

namespace EventManagement.Domain.Transactions
{
    public class UpdateCoffeePlaceTransaction : TransactionBase, IUpdateCoffeePlaceTransaction
    {
        private readonly ICoffeePlaceService _coffeePlaceService;

        public UpdateCoffeePlaceTransaction(
            IUnitOfWork unitOfWork,
            ICoffeePlaceService coffeePlaceService)
            : base(unitOfWork)
        {
            _coffeePlaceService = coffeePlaceService;
        }

        public async Task<CoffeePlaceResponse> Execute(UpdateCoffeePlaceCommand command)
        {
            var coffeePlace = await _coffeePlaceService
                .Update(command);

            await Commit();

            return new CoffeePlaceResponse(coffeePlace);
        }
    }
}