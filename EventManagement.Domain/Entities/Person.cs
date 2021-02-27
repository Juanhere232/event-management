using System.Collections.Generic;
using System.Linq;
using EventManagement.Domain.Commands;

namespace EventManagement.Domain.Entities
{
    public class Person : EntityBase<long>
    {
        private Person() { }

        public Person(CreatePersonCommand command) : this()
        {
            FirstName = command.FirstName;
            LastName = command.LastName;
            PersonCoffeePlaceAssociations = command.CoffeePlaces
                .Select(s => new PersonCoffeePlaceAssociation(this, s))
                .ToList();
            PersonEventRoomAssociations = command.EventRooms
                .Select(s => new PersonEventRoomAssociation(this, s))
                .ToList();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public ICollection<PersonCoffeePlaceAssociation> PersonCoffeePlaceAssociations { get; set; }
        public ICollection<PersonEventRoomAssociation> PersonEventRoomAssociations { get; set; }

        public void Update(UpdatePersonCommand command)
        {
            FirstName = command.FirstName;
            LastName = command.LastName;
            PersonCoffeePlaceAssociations = command.CoffeePlaces
                .Select(s => new PersonCoffeePlaceAssociation(this, s))
                .ToList();
            PersonEventRoomAssociations = command.EventRooms
                .Select(s => new PersonEventRoomAssociation(this, s))
                .ToList();
        }

        public static class Constraints
        {
            public const int FirstNameMaxLength = 100;
            public const int LastNameMaxLength = 100;
        }
    }
}