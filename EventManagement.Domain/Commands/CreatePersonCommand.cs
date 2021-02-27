using System.Collections.Generic;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Requests;

namespace EventManagement.Domain.Commands
{
    public class CreatePersonCommand
    {
        private CreatePersonCommand() { }

        public CreatePersonCommand(CreateUpdatePersonRequest request) : this()
        {
            FirstName = request.FirstName;
            LastName = request.LastName;
            CoffeePlaceIds = request.CoffeePlaces;
            EventRoomIds = request.EventRooms;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public IList<long> CoffeePlaceIds { get; private set; }
        public IList<long> EventRoomIds { get; private set; }
        public IList<CoffeePlace> CoffeePlaces { get; private set; }
        public IList<EventRoom> EventRooms { get; private set; }

        public void AddCoffeePlaces(IList<CoffeePlace> coffeePlaces) =>
            CoffeePlaces = coffeePlaces;

        public void AddEventRooms(IList<EventRoom> eventRooms) =>
            EventRooms = eventRooms;
    }
}