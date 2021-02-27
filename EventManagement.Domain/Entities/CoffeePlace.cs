using System.Collections.Generic;
using EventManagement.Domain.Commands;

namespace EventManagement.Domain.Entities
{
    public class CoffeePlace : EntityBase<long>
    {
        private CoffeePlace()
        {
            PersonCoffeePlaceAssociations = new List<PersonCoffeePlaceAssociation>();
        }

        public CoffeePlace(CreateCoffeePlaceCommand command) : this()
        {
            Name = command.Name;
        }

        public string Name { get; private set; }
        public ICollection<PersonCoffeePlaceAssociation> PersonCoffeePlaceAssociations { get; set; }

        public void Update(UpdateCoffeePlaceCommand command)
        {
            Name = command.Name;
        }

        public static class Constraints
        {
            public const int NameMaxLength = 100;
        }
    }
}