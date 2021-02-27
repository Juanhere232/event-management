using EventManagement.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EventManagement.Domain.Responses
{
    public struct CoffeePlaceWithDetailsResponse
    {
        public CoffeePlaceWithDetailsResponse(CoffeePlace coffeePlace)
        {
            CoffeePlaceId = coffeePlace.Id;
            Name = coffeePlace.Name;
            RegisteredPersons = coffeePlace
                .PersonCoffeePlaceAssociations
                .Select(s => s.Person)
                .Select(person => new PersonResponse(person))
                .ToList();
        }

        public long CoffeePlaceId { get; set; }
        public string Name { get; set; }
        public IList<PersonResponse> RegisteredPersons { get; set; }
    }
}