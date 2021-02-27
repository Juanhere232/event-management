using System.Collections.Generic;
using System.Linq;
using EventManagement.Domain.Entities;

namespace EventManagement.Domain.Responses
{
    public struct PersonWithDetailsResponse
    {
        public PersonWithDetailsResponse(Person person)
        {
            PersonId = person.Id;
            FirstName = person.FirstName;
            LastName = person.LastName;
            RegisteredEventRooms = person
                .PersonEventRoomAssociations
                .Select(s => s.EventRoom)
                .Select(s => new EventRoomResponse(s))
                .ToList();
            RegisteredCoffeePlaces = person
                .PersonCoffeePlaceAssociations
                .Select(s => s.CoffeePlace)
                .Select(s => new CoffeePlaceResponse(s))
                .ToList();
        }

        public long PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<EventRoomResponse> RegisteredEventRooms { get; set; }
        public IList<CoffeePlaceResponse> RegisteredCoffeePlaces { get; set; }
    }
}