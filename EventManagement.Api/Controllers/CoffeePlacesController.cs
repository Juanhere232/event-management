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
    [Route("coffee-places")]
    public class CoffeePlacesController : Controller
    {
        private readonly ICoffeePlaceService _coffeePlaceService;
        private readonly ICreateCoffeePlaceTransaction _createCoffeePlaceTransaction;
        private readonly IUpdateCoffeePlaceTransaction _updateCoffeePlaceTransaction;

        public CoffeePlacesController(
            ICoffeePlaceService coffeePlaceService,
            ICreateCoffeePlaceTransaction createCoffeePlaceTransaction,
            IUpdateCoffeePlaceTransaction updateCoffeePlaceTransaction)
        {
            _coffeePlaceService = coffeePlaceService;
            _createCoffeePlaceTransaction = createCoffeePlaceTransaction;
            _updateCoffeePlaceTransaction = updateCoffeePlaceTransaction;
        }

        [HttpGet]
        public async Task<ActionResult<IList<CoffeePlaceResponse>>> GetAll()
        {
            var coffeePlaces = await _coffeePlaceService.GetAll();

            return Ok(coffeePlaces);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CoffeePlaceWithDetailsResponse>> Get([FromRoute] long id)
        {
            var coffeePlace = await _coffeePlaceService.GetByIdWithDetails(id);

            return Ok(coffeePlace);
        }

        [HttpPost]
        public async Task<ActionResult<CoffeePlaceResponse>> Create([FromBody] CreateUpdateCoffeePlaceRequest request)
        {
            var coffeePlace = await _createCoffeePlaceTransaction.Execute(new CreateCoffeePlaceCommand(request));

            return Created("", coffeePlace);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CoffeePlaceResponse>> Update([FromRoute] long id, [FromBody] CreateUpdateCoffeePlaceRequest request)
        {
            CoffeePlaceResponse coffeePlace;
            try
            {
                coffeePlace = await _updateCoffeePlaceTransaction.Execute(new UpdateCoffeePlaceCommand(id, request));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

            return Ok(coffeePlace);
        }
    }
}