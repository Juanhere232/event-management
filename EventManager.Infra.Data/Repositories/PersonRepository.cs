using System.Linq;
using System.Threading.Tasks;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Infra.Data.Repositories
{
    public class PersonRepository : AsyncRepository<Person, long>, IPersonRepository
    {
        public PersonRepository(
            DbContext context)
            : base(context) { }

        public async Task<Person> GetByIdAsync(long id) =>
            await Set
                .Include(i => i.PersonEventRoomAssociations)
                    .ThenInclude(t => t.EventRoom)
                .Include(i => i.PersonCoffeePlaceAssociations)
                    .ThenInclude(t => t.CoffeePlace)
                .SingleOrDefaultAsync(s => Equals(s.Id, id));

        public async Task DeleteAssociationsByIdAsync(long id)
        {
            var coffeePlaces = await Context
                .Set<PersonCoffeePlaceAssociation>()
                .Where(w => Equals(w.PersonId, id))
                .ToListAsync();

            var eventRooms = await Context
                .Set<PersonEventRoomAssociation>()
                .Where(w => Equals(w.PersonId, id))
                .ToListAsync();

            Context
                .Set<PersonCoffeePlaceAssociation>()
                .RemoveRange(coffeePlaces.ToArray());
            Context
                .Set<PersonEventRoomAssociation>()
                .RemoveRange(eventRooms.ToArray());
        }
    }
}