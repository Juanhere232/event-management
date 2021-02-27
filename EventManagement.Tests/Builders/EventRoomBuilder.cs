using System.Collections.Generic;
using EventManagement.Domain.Entities;

namespace EventManagement.Tests.Builders
{
    public class EventRoomBuilder
    {
        private long _id = 1;
        private string _name = "John";
        private int _capacity = 20;
        private IList<PersonEventRoomAssociation> _persons = new List<PersonEventRoomAssociation>();

        public EventRoom Build() =>
            BuilderHelper
                .InstantiateClass<EventRoom>()
                .SetPropertyValue(eventRoom => eventRoom.Id, _id)
                .SetPropertyValue(eventRoom => eventRoom.Name, _name)
                .SetPropertyValue(eventRoom => eventRoom.Capacity, _capacity)
                .SetPropertyValue(eventRoom => eventRoom.PersonEventRoomAssociations, _persons);

        public EventRoomBuilder WithId(long id)
        {
            _id = id;
            return this;
        }
    }
}