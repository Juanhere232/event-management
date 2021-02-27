using System.Diagnostics.CodeAnalysis;
using EventManagement.Domain.Interfaces.Services;
using EventManagement.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EventManagement.Api.Registers
{
    [ExcludeFromCodeCoverage]
    public static class ServiceRegister
    {
        public static IServiceCollection RegisterServices(this IServiceCollection service)
        {
            service.AddScoped<ICoffeePlaceService, CoffeePlaceService>();
            service.AddScoped<IEventRoomService, EventRoomService>();
            service.AddScoped<IPersonService, PersonService>();

            return service;
        }
    }
}