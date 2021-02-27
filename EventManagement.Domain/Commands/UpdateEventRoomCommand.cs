using EventManagement.Domain.Requests;

namespace EventManagement.Domain.Commands
{
    public class UpdateEventRoomCommand
    {
        private UpdateEventRoomCommand() { }

        public UpdateEventRoomCommand(long id, CreateUpdateEventRoomRequest request) : this()
        {
            EventRoomId = id;
            Name = request.Name;
            Capacity = request.Capacity;
        }

        public long EventRoomId { get; private set; }
        public string Name { get; private set; }
        public int Capacity { get; private set; }
    }
}