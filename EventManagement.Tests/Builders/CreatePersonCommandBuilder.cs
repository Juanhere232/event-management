using System.Collections.Generic;
using EventManagement.Domain.Commands;

namespace EventManagement.Tests.Builders
{
    public class CreatePersonCommandBuilder
    {
        private string _firstName = "John";
        private string _lastName = "Doe";
        private IList<long> _coffeePlaceIds = new List<long> { 1 };
        private IList<long> _eventRoomIds = new List<long> { 1 };

        public CreatePersonCommand Build() =>
            BuilderHelper
                .InstantiateClass<CreatePersonCommand>()
                .SetPropertyValue(createPersonCommand => createPersonCommand.FirstName, _firstName)
                .SetPropertyValue(createPersonCommand => createPersonCommand.LastName, _lastName)
                .SetPropertyValue(createPersonCommand => createPersonCommand.CoffeePlaceIds, _coffeePlaceIds)
                .SetPropertyValue(createPersonCommand => createPersonCommand.EventRoomIds, _eventRoomIds);

        public CreatePersonCommandBuilder WithCoffeePlaceIds(IList<long> ids)
        {
            _coffeePlaceIds = ids;
            return this;
        }

        public CreatePersonCommandBuilder WithEventRoomIds(IList<long> ids)
        {
            _eventRoomIds = ids;
            return this;
        }
    }
}