using EventManagement.Domain.Commands;

namespace EventManagement.Tests.Builders
{
    public class UpdateCoffeePlaceCommandBuilder
    {
        private long _coffeePlaceId = 1;
        private string _name = "John";

        public UpdateCoffeePlaceCommand Build() =>
            BuilderHelper
                .InstantiateClass<UpdateCoffeePlaceCommand>()
                .SetPropertyValue(updateCoffeePlaceCommand => updateCoffeePlaceCommand.CoffeePlaceId, _coffeePlaceId)
                .SetPropertyValue(updateCoffeePlaceCommand => updateCoffeePlaceCommand.Name, _name);
    }
}