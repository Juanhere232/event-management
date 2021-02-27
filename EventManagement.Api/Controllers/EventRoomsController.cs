using EventManagement.Domain.Commands;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Interfaces.Services;
using EventManagement.Domain.Interfaces.Transactions;
using EventManagement.Domain.Requests;
using EventManagement.Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagement.Api.Controllers
{
    [Route("event-rooms")]
    public class EventRoomsController : Controller
    {
        private readonly IEventRoomService _eventRoomService;
        private readonly ICreateEventRoomPlaceTransaction _createEventRoomPlaceTransaction;
        private readonly IUpdateEventRoomTransaction _updateEventRoomTransaction;

        public EventRoomsController(
            IEventRoomService eventRoomService,
            ICreateEventRoomPlaceTransaction createEventRoomPlaceTransaction,
            IUpdateEventRoomTransaction updateEventRoomTransaction)
        {
            _eventRoomService = eventRoomService;
            _createEventRoomPlaceTransaction = createEventRoomPlaceTransaction;
            _updateEventRoomTransaction = updateEventRoomTransaction;
        }

        [HttpGet]
        public async Task<ActionResult<IList<EventRoomResponse>>> GetAll()
        {
            var eventRooms = await _eventRoomService.GetAll();

            return Ok(eventRooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventRoomWithDetailsResponse>> Get([FromRoute] long id)
        {
            var eventRoom = await _eventRoomService.GetByIdWithDetails(id);

            return Ok(eventRoom);
        }

        [HttpPost]
        public async Task<ActionResult<EventRoomResponse>> Create([FromBody] CreateUpdateEventRoomRequest request)
        {
            var eventRoom = await _createEventRoomPlaceTransaction.Execute(new CreateEventRoomCommand(request));

            return Created("", eventRoom);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EventRoomResponse>> Update([FromRoute] long id, [FromBody] CreateUpdateEventRoomRequest request)
        {
            EventRoomResponse eventRoom;
            try
            {
                eventRoom = await _updateEventRoomTransaction.Execute(new UpdateEventRoomCommand(id, request));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

            return Ok(eventRoom);
        }
    }
}