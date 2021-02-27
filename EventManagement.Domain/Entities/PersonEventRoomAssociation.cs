namespace EventManagement.Domain.Entities
{
    public class PersonEventRoomAssociation
    {
        private PersonEventRoomAssociation() { }

        public PersonEventRoomAssociation(Person person, EventRoom eventRoom) : this()
        {
            PersonId = person.Id;
            Person = person;
            EventRoomId = eventRoom.Id;
            EventRoom = eventRoom;
        }

        public Person Person { get; }
        public long PersonId { get; }
        public EventRoom EventRoom { get; }
        public long EventRoomId { get; }
    }
}