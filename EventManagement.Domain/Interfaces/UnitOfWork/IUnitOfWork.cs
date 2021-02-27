using System;
using System.Threading.Tasks;

namespace EventManagement.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
    }
}