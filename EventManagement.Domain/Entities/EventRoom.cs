using System.Collections.Generic;
using EventManagement.Domain.Commands;

namespace EventManagement.Domain.Entities
{
    public class EventRoom : EntityBase<long>
    {
        private EventRoom()
        {
            PersonEventRoomAssociations = new List<PersonEventRoomAssociation>();
        }

        public EventRoom(CreateEventRoomCommand command) : this()
        {
            Name = command.Name;
            Capacity = command.Capacity;
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public ICollection<PersonEventRoomAssociation> PersonEventRoomAssociations { get; set; }

        public void Update(UpdateEventRoomCommand command)
        {
            Name = command.Name;
            Capacity = command.Capacity;
        }

        public static class Constraints
        {
            public const int NameMaxLength = 100;
        }
    }
}