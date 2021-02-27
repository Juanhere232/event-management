using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Infra.Data.Repositories
{
    public class CoffeePlaceRepository : AsyncRepository<CoffeePlace, long>, ICoffeePlaceRepository
    {
        public CoffeePlaceRepository(
            DbContext context)
            : base(context) { }

        public async Task<CoffeePlace> GetByIdAsync(long id) =>
            await Set
                .Include(i => i.PersonCoffeePlaceAssociations)
                    .ThenInclude(t => t.Person)
                .SingleOrDefaultAsync(s => Equals(s.Id, id));

        public async Task<IList<CoffeePlace>> GetByIds(IList<long> coffeePlaceIds) =>
            await Set
                .Where(w => coffeePlaceIds.Contains(w.Id))
                .ToListAsync();
    }
}