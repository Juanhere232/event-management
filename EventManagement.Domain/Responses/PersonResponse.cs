using EventManagement.Domain.Entities;

namespace EventManagement.Domain.Responses
{
    public struct PersonResponse
    {
        public PersonResponse(Person person)
        {
            PersonId = person.Id;
            FirstName = person.FirstName;
            LastName = person.LastName;
        }

        public long PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}