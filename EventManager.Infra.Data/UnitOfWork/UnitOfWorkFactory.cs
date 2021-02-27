using System;
using System.Diagnostics.CodeAnalysis;
using EventManagement.Domain.Interfaces.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace EventManager.Infra.Data.UnitOfWork
{
    [ExcludeFromCodeCoverage]
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        [ThreadStatic]
        private static IUnitOfWork _unitOfWork;

        private readonly IServiceProvider _ioc;

        public UnitOfWorkFactory(IServiceProvider ioc)
        {
            _ioc = ioc;
        }

        public IUnitOfWork Create() =>
            CreateTransacion();

        private IUnitOfWork CreateTransacion()
        {
            if (_unitOfWork != null)
                throw new InvalidOperationException("UnitOfWork already started.");

            _unitOfWork = _ioc.GetService<IUnitOfWork>();

            if (_unitOfWork == null)
                throw new InvalidOperationException("UnitOfWork already ended.");

            return _unitOfWork;
        }
    }
}