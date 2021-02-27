using System.Diagnostics.CodeAnalysis;
using EventManagement.Domain.Interfaces.Transactions;
using EventManagement.Domain.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace EventManagement.Api.Registers
{
    [ExcludeFromCodeCoverage]
    public static class TransactionsRegister
    {
        public static IServiceCollection RegisterTransactions(this IServiceCollection service)
        {
            service.AddScoped<ICreateCoffeePlaceTransaction, CreateCoffeePlaceTransaction>();
            service.AddScoped<IUpdateCoffeePlaceTransaction, UpdateCoffeePlaceTransaction>();
            service.AddScoped<ICreateEventRoomPlaceTransaction, CreateEventRoomPlaceTransaction>();
            service.AddScoped<IUpdateEventRoomTransaction, UpdateEventRoomTransaction>();
            service.AddScoped<ICreatePersonTransaction, CreatePersonTransaction>();
            service.AddScoped<IUpdatePersonTransaction, UpdatePersonTransaction>();

            return service;
        }
    }
}