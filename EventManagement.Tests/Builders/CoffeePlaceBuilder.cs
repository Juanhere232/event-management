using EventManagement.Domain.Entities;
using System.Collections.Generic;

namespace EventManagement.Tests.Builders
{
    public class CoffeePlaceBuilder
    {
        private long _id = 1;
        private string _name = "John";
        private IList<PersonCoffeePlaceAssociation> _persons = new List<PersonCoffeePlaceAssociation>();

        public CoffeePlace Build() =>
            BuilderHelper
                .InstantiateClass<CoffeePlace>()
                .SetPropertyValue(coffeePlace => coffeePlace.Id, _id)
                .SetPropertyValue(coffeePlace => coffeePlace.Name, _name)
                .SetPropertyValue(coffeePlace => coffeePlace.PersonCoffeePlaceAssociations, _persons);

        public CoffeePlaceBuilder WithId(long id)
        {
            _id = id;
            return this;
        }
    }
}