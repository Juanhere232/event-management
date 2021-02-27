using System.Diagnostics.CodeAnalysis;
using EventManagement.Domain.Interfaces.Repositories;
using EventManager.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EventManagement.Api.Registers
{
    [ExcludeFromCodeCoverage]
    public static class RepositoryRegister
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection service)
        {
            service.AddScoped<ICoffeePlaceRepository, CoffeePlaceRepository>();
            service.AddScoped<IEventRoomRepository, EventRoomRepository>();
            service.AddScoped<IPersonRepository, PersonRepository>();

            return service;
        }
    }
}