namespace EventManagement.Domain.Requests
{
    public class CreateUpdateEventRoomRequest
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}