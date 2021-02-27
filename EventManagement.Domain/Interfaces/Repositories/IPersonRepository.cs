using System.Threading.Tasks;
using EventManagement.Domain.Entities;

namespace EventManagement.Domain.Interfaces.Repositories
{
    public interface IPersonRepository : IAsyncRepository<Person, long>
    {
        Task<Person> GetByIdAsync(long id);
        Task DeleteAssociationsByIdAsync(long id);
    }
}