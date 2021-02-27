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
    [Route("persons")]
    public class PersonsController : Controller
    {
        private readonly IPersonService _personService;
        private readonly ICreatePersonTransaction _createPersonTransaction;
        private readonly IUpdatePersonTransaction _updatePersonTransaction;

        public PersonsController(
            IPersonService personService,
            ICreatePersonTransaction createPersonTransaction,
            IUpdatePersonTransaction updatePersonTransaction)
        {
            _personService = personService;
            _createPersonTransaction = createPersonTransaction;
            _updatePersonTransaction = updatePersonTransaction;
        }

        [HttpGet]
        public async Task<ActionResult<IList<PersonResponse>>> GetAll()
        {
            var persons = await _personService.GetAll();

            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonWithDetailsResponse>> Get([FromRoute] long id)
        {
            var person = await _personService.GetByIdWithDetails(id);

            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<PersonWithDetailsResponse>> Create([FromBody] CreateUpdatePersonRequest request)
        {
            PersonWithDetailsResponse person;
            try
            {
                person = await _createPersonTransaction.Execute(new CreatePersonCommand(request));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

            return Created("", person);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonWithDetailsResponse>> Update([FromRoute] long id, [FromBody] CreateUpdatePersonRequest request)
        {
            PersonWithDetailsResponse person;
            try
            {
                person = await _updatePersonTransaction.Execute(new UpdatePersonCommand(id, request));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

            return Ok(person);
        }
    }
}