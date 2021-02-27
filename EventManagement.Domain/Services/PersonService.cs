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
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IEventRoomRepository _eventRoomRepository;
        private readonly ICoffeePlaceRepository _coffeePlaceRepository;

        public PersonService(
            IPersonRepository personRepository,
            IEventRoomRepository eventRoomRepository,
            ICoffeePlaceRepository coffeePlaceRepository)
        {
            _personRepository = personRepository;
            _eventRoomRepository = eventRoomRepository;
            _coffeePlaceRepository = coffeePlaceRepository;
        }

        public async Task<IList<PersonResponse>> GetAll()
        {
            var persons = await _personRepository
                .GetAllAsync();

            return persons
                .Select(person => new PersonResponse(person))
                .ToList();
        }

        public async Task<PersonWithDetailsResponse> GetByIdWithDetails(long id)
        {
            var person = await _personRepository
                .GetByIdAsync(id);

            return new PersonWithDetailsResponse(person);
        }

        public async Task<Person> Create(CreatePersonCommand command)
        {
            var coffeePlaces = await GetCoffeePlaces(command.CoffeePlaceIds);

            var eventRooms = await GetEventRooms(command.EventRoomIds);

            command.AddCoffeePlaces(coffeePlaces);
            command.AddEventRooms(eventRooms);

            var eventRoom = new Person(command);

            await _personRepository
                .AddAsync(eventRoom);

            return eventRoom;
        }

        public async Task<Person> Update(UpdatePersonCommand command)
        {
            var person = await _personRepository
                .GetByIdAsync(command.PersonId);

            if (person == null)
                throw new NotFoundException("Pessoa não encontrada.");

            await _personRepository
                .DeleteAssociationsByIdAsync(person.Id);

            var coffeePlaces = await GetCoffeePlaces(command.CoffeePlaceIds);

            var eventRooms = await GetEventRooms(command.EventRoomIds);

            command.AddCoffeePlaces(coffeePlaces);
            command.AddEventRooms(eventRooms);

            person.Update(command);

            return person;
        }

        private async Task<IList<CoffeePlace>> GetCoffeePlaces(IList<long> ids)
        {
            var coffeePlaces = await _coffeePlaceRepository
                .GetByIds(ids);

            foreach (var coffeePlaceId in ids)
            {
                var coffeePlace = coffeePlaces.FirstOrDefault(f => f.Id == coffeePlaceId);

                if (coffeePlace == default)
                    throw new NotFoundException("Cafeteria não encontrada.");
            }

            return coffeePlaces;
        }

        private async Task<IList<EventRoom>> GetEventRooms(IList<long> ids)
        {
            var eventRooms = await _eventRoomRepository
                .GetByIds(ids);

            foreach (var eventRoomId in ids)
            {
                var eventRoom = eventRooms.FirstOrDefault(f => f.Id == eventRoomId);

                if (eventRoom == default)
                    throw new NotFoundException("Sala de Evento não encontrada.");
            }

            return eventRooms;
        }
    }
}