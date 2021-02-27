using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagement.Domain.Entities;

namespace EventManagement.Domain.Interfaces.Repositories
{
    public interface IEventRoomRepository : IAsyncRepository<EventRoom, long>
    {
        Task<EventRoom> GetByIdAsync(long id);
        Task<IList<EventRoom>> GetByIds(IList<long> commandEventRoomIds);
    }
}