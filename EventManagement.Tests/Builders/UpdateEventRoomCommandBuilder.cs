using EventManagement.Domain.Commands;

namespace EventManagement.Tests.Builders
{
    public class UpdateEventRoomCommandBuilder
    {
        private long _eventRoomId = 1;
        private string _name = "John";
        private int _capacity = 20;

        public UpdateEventRoomCommand Build() =>
            BuilderHelper
                .InstantiateClass<UpdateEventRoomCommand>()
                .SetPropertyValue(updateEventRoomCommand => updateEventRoomCommand.EventRoomId, _eventRoomId)
                .SetPropertyValue(updateEventRoomCommand => updateEventRoomCommand.Name, _name)
                .SetPropertyValue(updateEventRoomCommand => updateEventRoomCommand.Capacity, _capacity);
    }
}