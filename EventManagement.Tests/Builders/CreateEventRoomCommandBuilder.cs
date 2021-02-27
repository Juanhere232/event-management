using EventManagement.Domain.Commands;

namespace EventManagement.Tests.Builders
{
    public class CreateEventRoomCommandBuilder
    {
        private string _name = "John";
        private int _capacity = 20;

        public CreateEventRoomCommand Build() =>
            BuilderHelper
                .InstantiateClass<CreateEventRoomCommand>()
                .SetPropertyValue(createEventRoomCommand => createEventRoomCommand.Name, _name)
                .SetPropertyValue(createEventRoomCommand => createEventRoomCommand.Capacity, _capacity);
    }
}