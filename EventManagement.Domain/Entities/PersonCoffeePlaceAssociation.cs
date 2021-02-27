namespace EventManagement.Domain.Entities
{
    public class PersonCoffeePlaceAssociation
    {
        private PersonCoffeePlaceAssociation() { }

        public PersonCoffeePlaceAssociation(Person person, CoffeePlace coffeePlace) : this()
        {
            PersonId = person.Id;
            Person = person;
            CoffeePlaceId = coffeePlace.Id;
            CoffeePlace = coffeePlace;
        }

        public Person Person { get; }
        public long PersonId { get; }
        public CoffeePlace CoffeePlace { get; }
        public long CoffeePlaceId { get; }
    }
}