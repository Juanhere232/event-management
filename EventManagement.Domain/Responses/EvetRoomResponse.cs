﻿using EventManagement.Domain.Entities;

namespace EventManagement.Domain.Responses
{
    public struct EvetRoomResponse
    {
        public EvetRoomResponse(EventRoom eventRoom)
        {
            EventRoomId = eventRoom.Id;
            Name = eventRoom.Name;
            Capacity = eventRoom.Capacity;
        }

        public long EventRoomId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}