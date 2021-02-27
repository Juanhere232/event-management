using System.Collections.Generic;
using EventManagement.Domain.Commands;

namespace EventManagement.Tests.Builders
{
    public class UpdatePersonCommandBuilder
    {
        private long _personId = 1;
        private string _firstName = "John";
        private string _lastName = "Doe";
        private IList<long> _coffeePlaceIds = new List<long> { 1 };
        private IList<long> _eventRoomIds = new List<long> { 1 };

        public UpdatePersonCommand Build() =>
            BuilderHelper
                .InstantiateClass<UpdatePersonCommand>()
                .SetPropertyValue(updatePersonCommand => updatePersonCommand.PersonId, _personId)
                .SetPropertyValue(updatePersonCommand => updatePersonCommand.FirstName, _firstName)
                .SetPropertyValue(updatePersonCommand => updatePersonCommand.LastName, _lastName)
                .SetPropertyValue(updatePersonCommand => updatePersonCommand.CoffeePlaceIds, _coffeePlaceIds)
                .SetPropertyValue(updatePersonCommand => updatePersonCommand.EventRoomIds, _eventRoomIds);

        public UpdatePersonCommandBuilder WithCoffeePlaceIds(IList<long> ids)
        {
            _coffeePlaceIds = ids;
            return this;
        }

        public UpdatePersonCommandBuilder WithEventRoomIds(IList<long> ids)
        {
            _eventRoomIds = ids;
            return this;
        }
    }
}