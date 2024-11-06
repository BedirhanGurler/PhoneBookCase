using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookApi.Business.Abstract;
using PhoneBookApi.Core.ValidationRules;
using PhoneBookApi.Models.Concrete;
using PhoneBookApi.Models.DTO;

namespace PhoneBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;
        
        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("active-persons")]
        public IActionResult GetAllActivePersons()
        {
            var persons = _personService.GetAllActivePersons().ToList();
            if(persons == null)
            {
                return NotFound();
            }
            return Ok(persons);
        }

        [HttpGet("inactive-persons")]
        public IActionResult GetInActivePersons()
        {
            var persons = _personService.GetAllInactivePersons().ToList();
            if (persons == null)
            {
                return NotFound();
            }
            return Ok(persons);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetActivePersonById(int id)
        {
            var person = await _personService.GetActivePersonById(id);
            if(person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost("new-person")]
        public async Task<IActionResult> CreateNewPerson([FromBody] PersonDTO person)
        {
            var valid = new PersonValidator();
            var result = valid.Validate(person);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }
            await _personService.CreateNewPerson(person);
            return Ok(person);
        }

        [HttpPut("update-person/{id}")]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] PersonDTO person)
        {
            var valid = new PersonValidator();
            var result = valid.Validate(person);

            if (!result.IsValid)
            {
                return BadRequest(result);
            }

            await _personService.UpdatePerson(person);
            return NoContent();
        }

        [HttpDelete("delete-person/{id}")]
        public async Task<IActionResult> DeletePersonById(int id)
        {
            await _personService.DeletePersonById(id);
            return NoContent();
        }

        [HttpDelete("activate-person/{id}")]
        public async Task<IActionResult> ActivatePerson(int id)
        {
            await _personService.ActivatePerson(id);
            return NoContent();
        }
    }
}
