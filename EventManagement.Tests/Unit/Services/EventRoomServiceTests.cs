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
    public class EventRoomServiceTests
    {
        private readonly IEventRoomRepository _eventRoomRepository;
        private readonly IEventRoomService _eventRoomService;

        public EventRoomServiceTests()
        {
            _eventRoomRepository = Substitute.For<IEventRoomRepository>();

            _eventRoomService = new EventRoomService(_eventRoomRepository);
        }

        [Fact]
        public async Task Should_get_all_event_rooms()
        {
            var eventRoom1 = new EventRoomBuilder()
                .Build();
            var eventRoom2 = new EventRoomBuilder()
                .Build();
            var eventRooms = new List<EventRoom> { eventRoom1, eventRoom2 };

            _eventRoomRepository
                .GetAllAsync()
                .Returns(eventRooms);

            var eventRoomsResponse = await _eventRoomService
                .GetAll();

            eventRoomsResponse
                .Should()
                .SatisfyRespectively(
                    item1 =>
                    {
                        item1
                            .Should()
                            .BeEquivalentTo(eventRoom1, opt => opt.ExcludingMissingMembers());
                    },
                    item2 =>
                    {
                        item2
                            .Should()
                            .BeEquivalentTo(eventRoom2, opt => opt.ExcludingMissingMembers());
                    });
        }

        [Fact]
        public async Task Should_get_a_event_room_by_id()
        {
            const long eventRoomId = 1;

            var eventRoom = new EventRoomBuilder()
                .WithId(eventRoomId)
                .Build();

            _eventRoomRepository
                .GetByIdAsync(eventRoomId)
                .Returns(eventRoom);

            var ceventRoomResponse = await _eventRoomService
                .GetByIdWithDetails(eventRoomId);

            ceventRoomResponse
                .Should()
                .BeEquivalentTo(eventRoom, opt => opt.ExcludingMissingMembers());
        }

        [Fact]
        public async Task Should_create_a_event_room()
        {
            var command = new CreateEventRoomCommandBuilder()
                .Build();

            var eventRoom = await _eventRoomService
                .Create(command);

            await _eventRoomRepository
                .Received(1)
                .AddAsync(Arg.Is<EventRoom>(a =>
                    a.Name == command.Name &&
                    a.Capacity == command.Capacity));

            eventRoom
                .Name
                .Should()
                .Be(command.Name);
            eventRoom
                .Capacity
                .Should()
                .Be(command.Capacity);
            eventRoom
                .PersonEventRoomAssociations
                .Should()
                .BeEmpty();
        }

        [Fact]
        public async Task Should_update_a_coffee_place()
        {
            var command = new UpdateEventRoomCommandBuilder()
                .Build();

            var eventRoom = new EventRoomBuilder()
                .WithId(command.EventRoomId)
                .Build();

            _eventRoomRepository
                .GetByIdAsync(command.EventRoomId)
                .Returns(eventRoom);

            var response = await _eventRoomService
                .Update(command);

            response
                .Id
                .Should()
                .Be(command.EventRoomId);
            response
                .Name
                .Should()
                .Be(command.Name);
            response
                .Capacity
                .Should()
                .Be(command.Capacity);
            response
                .PersonEventRoomAssociations
                .Should()
                .BeEmpty();
        }

        [Fact]
        public void Should_not_update_a_event_room_if_they_are_not_found()
        {
            var command = new UpdateEventRoomCommandBuilder()
                .Build();

            _eventRoomRepository
                .GetByIdAsync(command.EventRoomId)
                .ReturnsNull();

            Action act = () => _eventRoomService
                .Update(command)
                .GetAwaiter()
                .GetResult();

            act
                .Should()
                .Throw<NotFoundException>()
                .Where(w => w.Message == "Sala de Evento não encontrada");
        }
    }
}