using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagement.Domain.Entities;

namespace EventManagement.Domain.Interfaces.Repositories
{
    public interface ICoffeePlaceRepository : IAsyncRepository<CoffeePlace, long>
    {
        Task<CoffeePlace> GetByIdAsync(long id);
        Task<IList<CoffeePlace>> GetByIds(IList<long> coffeePlaceIds);
    }
}