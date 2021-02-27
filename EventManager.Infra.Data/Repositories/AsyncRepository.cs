using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Infra.Data.Repositories
{
    public abstract class AsyncRepository<TEntity, TKey>
        : IAsyncRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> Set;

        protected AsyncRepository(DbContext context)
        {
            Context = context;
            Set = context.Set<TEntity>();
        }

        public async Task<IList<TEntity>> GetAllAsync() =>
            await Set.ToListAsync();

        public async Task AddAsync(TEntity entity) =>
            await Set.AddAsync(entity);
    }
}