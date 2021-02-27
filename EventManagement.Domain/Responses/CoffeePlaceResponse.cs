using EventManagement.Domain.Entities;

namespace EventManagement.Domain.Responses
{
    public struct CoffeePlaceResponse
    {
        public CoffeePlaceResponse(CoffeePlace coffeePlace)
        {
            CoffeePlaceId = coffeePlace.Id;
            Name = coffeePlace.Name;
        }

        public long CoffeePlaceId { get; set; }
        public string Name { get; set; }
    }
}