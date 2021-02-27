using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagement.Domain.Commands;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Responses;

namespace EventManagement.Domain.Interfaces.Services
{
    public interface IPersonService
    {
        Task<IList<PersonResponse>> GetAll();
        Task<PersonWithDetailsResponse> GetByIdWithDetails(long id);
        Task<Person> Create(CreatePersonCommand command);
        Task<Person> Update(UpdatePersonCommand command);
    }
}