using EventManagement.Domain.Commands;
using EventManagement.Domain.Interfaces.Transactions;
using EventManagement.Domain.Interfaces.UnitOfWork;
using EventManagement.Domain.Responses;
using System.Threading.Tasks;
using EventManagement.Domain.Interfaces.Services;

namespace EventManagement.Domain.Transactions
{
    public class CreatePersonTransaction : TransactionBase, ICreatePersonTransaction
    {
        private readonly IPersonService _personService;

        public CreatePersonTransaction(
            IUnitOfWork unitOfWork,
            IPersonService personService)
            : base(unitOfWork)
        {
            _personService = personService;
        }

        public async Task<PersonWithDetailsResponse> Execute(CreatePersonCommand command)
        {
            var person = await _personService
                .Create(command);

            await Commit();

            return new PersonWithDetailsResponse(person);
        }
    }
}