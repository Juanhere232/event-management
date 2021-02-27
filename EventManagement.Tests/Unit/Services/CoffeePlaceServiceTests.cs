using System;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Interfaces.Repositories;
using EventManagement.Domain.Interfaces.Services;
using EventManagement.Domain.Services;
using EventManagement.Tests.Builders;
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagement.Domain.Exceptions;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace EventManagement.Tests.Unit.Services
{
    public class CoffeePlaceServiceTests
    {
        private readonly ICoffeePlaceService _coffeePlaceService;
        private readonly ICoffeePlaceRepository _coffeePlaceRepository;

        public CoffeePlaceServiceTests()
        {
            _coffeePlaceRepository = Substitute.For<ICoffeePlaceRepository>();

            _coffeePlaceService = new CoffeePlaceService(_coffeePlaceRepository);
        }

        [Fact]
        public async Task Should_get_all_coffee_places()
        {
            var coffeePlace1 = new CoffeePlaceBuilder()
                .Build();
            var coffeePlace2 = new CoffeePlaceBuilder()
                .Build();
            var coffeePlaces = new List<CoffeePlace> { coffeePlace1, coffeePlace2 };

            _coffeePlaceRepository
                .GetAllAsync()
                .Returns(coffeePlaces);

            var coffeePlacesResponse = await _coffeePlaceService
                .GetAll();

            coffeePlacesResponse
                .Should()
                .SatisfyRespectively(
                    item1 =>
                    {
                        item1
                            .Should()
                            .BeEquivalentTo(coffeePlace1, opt => opt.ExcludingMissingMembers());
                    },
                    item2 =>
                    {
                        item2
                            .Should()
                            .BeEquivalentTo(coffeePlace2, opt => opt.ExcludingMissingMembers());
                    });
        }

        [Fact]
        public async Task Should_get_a_coffee_place_by_id()
        {
            const long coffeePlaceId = 1;

            var coffeePlace = new CoffeePlaceBuilder()
                .WithId(coffeePlaceId)
                .Build();

            _coffeePlaceRepository
                .GetByIdAsync(coffeePlaceId)
                .Returns(coffeePlace);

            var coffeePlaceResponse = await _coffeePlaceService
                .GetByIdWithDetails(coffeePlaceId);

            coffeePlaceResponse
                .Should()
                .BeEquivalentTo(coffeePlace, opt => opt.ExcludingMissingMembers());
        }

        [Fact]
        public async Task Should_create_a_coffee_place()
        {
            var command = new CreateCoffeePlaceCommandBuilder()
                .Build();

            var coffeePlace = await _coffeePlaceService
                .Create(command);

            await _coffeePlaceRepository
                .Received(1)
                .AddAsync(Arg.Is<CoffeePlace>(a =>
                    a.Name == command.Name));

            coffeePlace
                .Name
                .Should()
                .Be(command.Name);
            coffeePlace
                .PersonCoffeePlaceAssociations
                .Should()
                .BeEmpty();
        }

        [Fact]
        public async Task Should_update_a_coffee_place()
        {
            var command = new UpdateCoffeePlaceCommandBuilder()
                .Build();

            var coffeePlace = new CoffeePlaceBuilder()
                .WithId(command.CoffeePlaceId)
                .Build();

            _coffeePlaceRepository
                .GetByIdAsync(command.CoffeePlaceId)
                .Returns(coffeePlace);

            var response = await _coffeePlaceService
                .Update(command);

            response
                .Id
                .Should()
                .Be(command.CoffeePlaceId);
            response
                .Name
                .Should()
                .Be(command.Name);
            response
                .PersonCoffeePlaceAssociations
                .Should()
                .BeEmpty();
        }

        [Fact]
        public void Should_not_update_a_coffee_place_if_they_are_not_found()
        {
            var command = new UpdateCoffeePlaceCommandBuilder()
                .Build();

            _coffeePlaceRepository
                .GetByIdAsync(command.CoffeePlaceId)
                .ReturnsNull();

            Action act = () => _coffeePlaceService
                .Update(command)
                .GetAwaiter()
                .GetResult();

            act
                .Should()
                .Throw<NotFoundException>()
                .Where(w => w.Message == "Cafeteria não encontrada");
        }
    }
}