using EventManagement.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EventManagement.Domain.Responses
{
    public struct EventRoomWithDetailsResponse
    {
        public EventRoomWithDetailsResponse(EventRoom eventRoom)
        {
            EventRoomId = eventRoom.Id;
            Name = eventRoom.Name;
            Capacity = eventRoom.Capacity;
            RegisteredPersons = eventRoom
                .PersonEventRoomAssociations
                .Select(s => s.Person)
                .Select(s => new PersonResponse(s))
                .ToList();
        }

        public long EventRoomId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public IList<PersonResponse> RegisteredPersons { get; set; }
    }
}