using EventManagement.Domain.Commands;
using EventManagement.Domain.Interfaces.Services;
using EventManagement.Domain.Interfaces.Transactions;
using EventManagement.Domain.Interfaces.UnitOfWork;
using EventManagement.Domain.Responses;
using System.Threading.Tasks;

namespace EventManagement.Domain.Transactions
{
    public class UpdatePersonTransaction : TransactionBase, IUpdatePersonTransaction
    {
        private readonly IPersonService _personService;

        public UpdatePersonTransaction(
            IUnitOfWork unitOfWork,
            IPersonService personService)
            : base(unitOfWork)
        {
            _personService = personService;
        }

        public async Task<PersonWithDetailsResponse> Execute(UpdatePersonCommand command)
        {
            var person = await _personService
                .Update(command);

            await Commit();

            return new PersonWithDetailsResponse(person);
        }
    }
}