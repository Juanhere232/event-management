using EventManagement.Domain.Requests;

namespace EventManagement.Domain.Commands
{
    public class CreateCoffeePlaceCommand
    {
        private CreateCoffeePlaceCommand() { }

        public CreateCoffeePlaceCommand(CreateUpdateCoffeePlaceRequest request) : this()
        {
            Name = request.Name;
        }

        public string Name { get; private set; }
    }
}