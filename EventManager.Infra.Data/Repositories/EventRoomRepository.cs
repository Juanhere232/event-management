using System.Collections.Generic;
using System.Linq;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EventManager.Infra.Data.Repositories
{
    public class EventRoomRepository : AsyncRepository<EventRoom, long>, IEventRoomRepository
    {
        public EventRoomRepository(
            DbContext context)
            : base(context) { }

        public async Task<EventRoom> GetByIdAsync(long id) =>
            await Set
                .Include(i => i.PersonEventRoomAssociations)
                    .ThenInclude(t => t.Person)
                .SingleOrDefaultAsync(s => Equals(s.Id, id));

        public async Task<IList<EventRoom>> GetByIds(IList<long> eventRoomIds) =>
            await Set
                .Where(w => eventRoomIds.Contains(w.Id))
                .ToListAsync();
    }
}