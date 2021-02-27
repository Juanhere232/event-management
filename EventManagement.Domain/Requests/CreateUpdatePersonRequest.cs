using System.Collections.Generic;

namespace EventManagement.Domain.Requests
{
    public class CreateUpdatePersonRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<long> CoffeePlaces { get; set; }
        public IList<long> EventRooms { get; set; }
    }
}