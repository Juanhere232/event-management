using EventManagement.Domain.Requests;

namespace EventManagement.Domain.Commands
{
    public class UpdateCoffeePlaceCommand
    {
        private UpdateCoffeePlaceCommand() { }

        public UpdateCoffeePlaceCommand(long coffeePlaceId, CreateUpdateCoffeePlaceRequest request) : this()
        {
            CoffeePlaceId = coffeePlaceId;
            Name = request.Name;
        }

        public long CoffeePlaceId { get; private set;}
        public string Name { get; private set; }
    }
}