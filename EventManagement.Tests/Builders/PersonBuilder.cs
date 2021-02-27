using EventManagement.Domain.Entities;
using System.Collections.Generic;

namespace EventManagement.Tests.Builders
{
    public class PersonBuilder
    {
        private long _id = 1;
        private string _firstName = "John";
        private string _lastName = "Doe";
        private IList<PersonCoffeePlaceAssociation> _coffeePlaces = new List<PersonCoffeePlaceAssociation>();
        private IList<PersonEventRoomAssociation> _eventRooms = new List<PersonEventRoomAssociation>();

        public Person Build() =>
            BuilderHelper
                .InstantiateClass<Person>()
                .SetPropertyValue(coffeePlace => coffeePlace.Id, _id)
                .SetPropertyValue(coffeePlace => coffeePlace.FirstName, _firstName)
                .SetPropertyValue(coffeePlace => coffeePlace.LastName, _lastName)
                .SetPropertyValue(coffeePlace => coffeePlace.PersonCoffeePlaceAssociations, _coffeePlaces)
                .SetPropertyValue(coffeePlace => coffeePlace.PersonEventRoomAssociations, _eventRooms);

        public PersonBuilder WithId(long id)
        {
            _id = id;
            return this;
        }
    }
}