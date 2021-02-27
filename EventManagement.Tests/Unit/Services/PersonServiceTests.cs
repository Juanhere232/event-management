using EventManagement.Domain.Entities;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Interfaces.Repositories;
using EventManagement.Domain.Interfaces.Services;
using EventManagement.Domain.Services;
using EventManagement.Tests.Builders;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EventManagement.Tests.Unit.Services
{
    public class PersonServiceTests
    {
        private readonly IPersonService _personService;
        private readonly IPersonRepository _personRepository;
        private readonly IEventRoomRepository _eventRoomRepository;
        private readonly ICoffeePlaceRepository _coffeePlaceRepository;

        public PersonServiceTests()
        {
            _personRepository = Substitute.For<IPersonRepository>();
            _eventRoomRepository = Substitute.For<IEventRoomRepository>();
            _coffeePlaceRepository = Substitute.For<ICoffeePlaceRepository>();

            _personService = new PersonService(_personRepository, _eventRoomRepository, _coffeePlaceRepository);
        }

        [Fact]
        public async Task Should_get_all_persons()
        {
            var person1 = new PersonBuilder()
                .Build();
            var person2 = new PersonBuilder()
                .Build();
            var persons = new List<Person> { person1, person2 };

            _personRepository
                .GetAllAsync()
                .Returns(persons);

            var personsResponse = await _personService
                .GetAll();

            personsResponse
                .Should()
                .SatisfyRespectively(item1 =>
                    {
                        item1
                            .Should()
                            .BeEquivalentTo(person1, opt => opt.ExcludingMissingMembers());
                    },
                    item2 =>
                    {
                        item2
                            .Should()
                            .BeEquivalentTo(person2, opt => opt.ExcludingMissingMembers());
                    });
        }

        [Fact]
        public async Task Should_get_a_person_by_id()
        {
            const long personId = 1;

            var person = new PersonBuilder()
                .WithId(personId)
                .Build();

            _personRepository
                .GetByIdAsync(personId)
                .Returns(person);

            var personsReponse = await _personService
                .GetByIdWithDetails(personId);

            personsReponse
                .Should()
                .BeEquivalentTo(person, opt => opt.ExcludingMissingMembers());
        }

        [Fact]
        public async Task Should_create_a_person()
        {
            var coffeePlace = new CoffeePlaceBuilder()
                .Build();
            var eventRoom = new EventRoomBuilder()
                .Build();

            var command = new CreatePersonCommandBuilder()
                .WithCoffeePlaceIds(new List<long> { coffeePlace.Id })
                .WithEventRoomIds(new List<long> { eventRoom.Id })
                .Build();

            _coffeePlaceRepository
                .GetByIds(command.CoffeePlaceIds)
                .Returns(new List<CoffeePlace> { coffeePlace });

            _eventRoomRepository
                .GetByIds(command.EventRoomIds)
                .Returns(new List<EventRoom> { eventRoom });

            var person = await _personService
                .Create(command);

            await _personRepository
                .Received(1)
                .AddAsync(Arg.Is<Person>(a =>
                    Equals(a.FirstName, command.FirstName) &&
                    Equals(a.LastName, command.LastName) &&
                    a.PersonCoffeePlaceAssociations.Count == 1 &&
                    a.PersonEventRoomAssociations.Count == 1));

            person
                .Should()
                .NotBeNull();
        }

        [Fact]
        public async Task Should_update_a_person()
        {
            var coffeePlace = new CoffeePlaceBuilder()
                .Build();
            var eventRoom = new EventRoomBuilder()
                .Build();

            var command = new UpdatePersonCommandBuilder()
                .WithCoffeePlaceIds(new List<long> { coffeePlace.Id })
                .WithEventRoomIds(new List<long> { eventRoom.Id })
                .Build();

            var person = new PersonBuilder()
                .WithId(command.PersonId)
                .Build();

            _coffeePlaceRepository
                .GetByIds(command.CoffeePlaceIds)
                .Returns(new List<CoffeePlace> { coffeePlace });

            _eventRoomRepository
                .GetByIds(command.EventRoomIds)
                .Returns(new List<EventRoom> { eventRoom });

            _personRepository
                .GetByIdAsync(command.PersonId)
                .Returns(person);

            var personResponse = await _personService
                .Update(command);

            personResponse
                .Should()
                .BeEquivalentTo(command, opt => opt.ExcludingMissingMembers());

            await _personRepository
                .Received(1)
                .DeleteAssociationsByIdAsync(command.PersonId);
        }

        [Fact]
        public async Task Should_not_update_a_person_if_they_are_not_found()
        {
            var command = new UpdatePersonCommandBuilder()
                .Build();

            _personRepository
                .GetByIdAsync(command.PersonId)
                .ReturnsNull();

            Action act = () => _personService
                .Update(command)
                .GetAwaiter()
                .GetResult();

            act
                .Should()
                .Throw<NotFoundException>()
                .Where(w => w.Message == "Pessoa não encontrada.");

            await _coffeePlaceRepository
                .DidNotReceiveWithAnyArgs()
                .GetByIds(default);
            await _eventRoomRepository
                .DidNotReceiveWithAnyArgs()
                .GetByIds(default);
            await _personRepository
                .DidNotReceiveWithAnyArgs()
                .DeleteAssociationsByIdAsync(default);
        }

        [Fact]
        public async Task Should_not_create_a_person_if_the_coffee_place_is_invalid()
        {
            var command = new CreatePersonCommandBuilder()
                .Build();

            _coffeePlaceRepository
                .GetByIds(command.CoffeePlaceIds)
                .Returns(new List<CoffeePlace>());

            Action act = () => _personService
                .Create(command)
                .GetAwaiter()
                .GetResult();

            act
                .Should()
                .Throw<NotFoundException>()
                .Where(w => w.Message == "Cafeteria não encontrada.");

            await _personRepository
                .DidNotReceiveWithAnyArgs()
                .AddAsync(default);
        }

        [Fact]
        public async Task Should_not_create_a_person_if_the_event_room_is_invalid()
        {
            var coffeePlace = new CoffeePlaceBuilder()
                .Build();

            var command = new CreatePersonCommandBuilder()
                .WithCoffeePlaceIds(new List<long> { coffeePlace.Id })
                .Build();

            _coffeePlaceRepository
                .GetByIds(command.CoffeePlaceIds)
                .Returns(new List<CoffeePlace> { coffeePlace });

            _eventRoomRepository
                .GetByIds(command.CoffeePlaceIds)
                .Returns(new List<EventRoom>());

            Action act = () => _personService
                .Create(command)
                .GetAwaiter()
                .GetResult();

            act
                .Should()
                .Throw<NotFoundException>()
                .Where(w => w.Message == "Sala de Evento não encontrada.");

            await _personRepository
                .DidNotReceiveWithAnyArgs()
                .AddAsync(default);
        }

        [Fact]
        public void Should_not_update_a_person_if_the_coffee_place_is_invalid()
        {
            var command = new UpdatePersonCommandBuilder()
                .Build();

            var person = new PersonBuilder()
                .WithId(command.PersonId)
                .Build();

            _coffeePlaceRepository
                .GetByIds(command.CoffeePlaceIds)
                .Returns(new List<CoffeePlace>());

            _personRepository
                .GetByIdAsync(command.PersonId)
                .Returns(person);

            Action act = () => _personService
                .Update(command)
                .GetAwaiter()
                .GetResult();

            act
                .Should()
                .Throw<NotFoundException>()
                .Where(w => w.Message == "Cafeteria não encontrada.");
        }

        [Fact]
        public void Should_not_update_a_person_if_the_event_room_is_invalid()
        {
            var coffeePlace = new CoffeePlaceBuilder()
                .Build();

            var command = new UpdatePersonCommandBuilder()
                .WithCoffeePlaceIds(new List<long> { coffeePlace.Id })
                .Build();

            var person = new PersonBuilder()
                .WithId(command.PersonId)
                .Build();

            _coffeePlaceRepository
                .GetByIds(command.CoffeePlaceIds)
                .Returns(new List<CoffeePlace> { coffeePlace });

            _eventRoomRepository
                .GetByIds(command.EventRoomIds)
                .Returns(new List<EventRoom>());

            _personRepository
                .GetByIdAsync(command.PersonId)
                .Returns(person);

            Action act = () => _personService
                .Update(command)
                .GetAwaiter()
                .GetResult();

            act
                .Should()
                .Throw<NotFoundException>()
                .Where(w => w.Message == "Sala de Evento não encontrada.");
        }
    }
}