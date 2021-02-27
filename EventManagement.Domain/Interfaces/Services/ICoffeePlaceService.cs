using EventManagement.Domain.Commands;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagement.Domain.Interfaces.Services
{
    public interface ICoffeePlaceService
    {
        Task<IList<CoffeePlaceResponse>> GetAll();
        Task<CoffeePlaceWithDetailsResponse> GetByIdWithDetails(long id);
        Task<CoffeePlace> Create(CreateCoffeePlaceCommand command);
        Task<CoffeePlace> Update(UpdateCoffeePlaceCommand command);
    }
}