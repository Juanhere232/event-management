using System.Collections.Generic;
using EventManagement.Domain.Entities;
using System.Threading.Tasks;

namespace EventManagement.Domain.Interfaces.Repositories
{
    public interface IAsyncRepository<TEntity, in TKey> where TEntity : EntityBase<TKey>
    {
        Task<IList<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
    }
}