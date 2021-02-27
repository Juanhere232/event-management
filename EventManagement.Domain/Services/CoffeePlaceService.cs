using EventManagement.Domain.Commands;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Interfaces.Repositories;
using EventManagement.Domain.Interfaces.Services;
using EventManagement.Domain.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Domain.Services
{
    public class CoffeePlaceService : ICoffeePlaceService
    {
        private readonly ICoffeePlaceRepository _coffeePlaceRepository;

        public CoffeePlaceService(
            ICoffeePlaceRepository coffeePlaceRepository)
        {
            _coffeePlaceRepository = coffeePlaceRepository;
        }

        public async Task<IList<CoffeePlaceResponse>> GetAll()
        {
            var coffeePlaces = await _coffeePlaceRepository
                .GetAllAsync();

            return coffeePlaces
                .Select(coffeePlace => new CoffeePlaceResponse(coffeePlace))
                .ToList();
        }

        public async Task<CoffeePlaceWithDetailsResponse> GetByIdWithDetails(long id)
        {
            var coffeePlace = await _coffeePlaceRepository
                .GetByIdAsync(id);

            return new CoffeePlaceWithDetailsResponse(coffeePlace);
        }

        public async Task<CoffeePlace> Create(CreateCoffeePlaceCommand command)
        {
            var coffeePlace = new CoffeePlace(command);

            await _coffeePlaceRepository
                .AddAsync(coffeePlace);

            return coffeePlace;
        }

        public async Task<CoffeePlace> Update(UpdateCoffeePlaceCommand command)
        {
            var coffeePlace = await _coffeePlaceRepository
                .GetByIdAsync(command.CoffeePlaceId);

            if (coffeePlace == null)
                throw new NotFoundException("Cafeteria não encontrada");

            coffeePlace.Update(command);

            return coffeePlace;
        }
    }
}