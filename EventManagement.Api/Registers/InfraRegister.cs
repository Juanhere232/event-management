using System.Diagnostics.CodeAnalysis;
using EventManagement.Domain.Interfaces.UnitOfWork;
using EventManager.Infra.Data.Contexts;
using EventManager.Infra.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventManagement.Api.Registers
{
    [ExcludeFromCodeCoverage]
    public static class InfraRegister
    {
        public static IServiceCollection RegisterInfra(this IServiceCollection service)
        {
            service.AddScoped<DbContext, EventManagementContext>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();

            return service;
        }
    }
}