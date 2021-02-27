using System.Diagnostics.CodeAnalysis;
using EventManagement.Domain.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EventManager.Infra.Data.UnitOfWork
{
    [ExcludeFromCodeCoverage]
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext Context;

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public void Dispose() =>
            Context?.Dispose();

        public async Task Commit() =>
            await Context.SaveChangesAsync();
    }
}