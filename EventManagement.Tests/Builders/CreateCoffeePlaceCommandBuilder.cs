using EventManagement.Domain.Commands;

namespace EventManagement.Tests.Builders
{
    public class CreateCoffeePlaceCommandBuilder
    {
        private string _name = "John";

        public CreateCoffeePlaceCommand Build() =>
            BuilderHelper
                .InstantiateClass<CreateCoffeePlaceCommand>()
                .SetPropertyValue(createCoffeePlaceCommand => createCoffeePlaceCommand.Name, _name);
	}
}