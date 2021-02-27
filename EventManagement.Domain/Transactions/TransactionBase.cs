using System.Threading.Tasks;
using EventManagement.Domain.Interfaces.UnitOfWork;

namespace EventManagement.Domain.Transactions
{
    public abstract class TransactionBase
    {
        private readonly IUnitOfWork _unitOfWork;

        protected TransactionBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async Task Commit() =>
            await _unitOfWork.Commit();
    }
}