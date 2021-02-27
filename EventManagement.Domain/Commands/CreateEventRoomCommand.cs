using EventManagement.Domain.Requests;

namespace EventManagement.Domain.Commands
{
    public class CreateEventRoomCommand
    {
        private CreateEventRoomCommand() { }

        public CreateEventRoomCommand(CreateUpdateEventRoomRequest request) : this()
        {
            Name = request.Name;
            Capacity = request.Capacity;
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
    }
}