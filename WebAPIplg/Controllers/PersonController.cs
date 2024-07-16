using Azure;
using Microsoft.AspNetCore.Mvc;
using WebAPIplg.DTO.Person;
using WebAPIplg.Models;
using WebAPIplg.Services.PersonService;

namespace WebAPIplg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        //TODO: Update Get/Post methods with proper responce codes and messages

        [HttpGet("GetAllPeople")]
        public async Task<ActionResult<ServiceResponce<List<PersonDTO>>>> GetAllPeople()
        {
            var responce = await _personService.GetAllPeople();
            if (responce == null)
            {
                return NotFound(responce);
            }
            else
            {
                return Ok(responce);
            }

        }

        [HttpGet("GetPerson/{id}")]
        public async Task<ActionResult<ServiceResponce<PersonDTO>>> GetPerson(int id)
        {
            var responce = await _personService.GetPersonById(id);
            if (responce == null)
            {
                return NotFound(responce);
            }
            else
            {
                return Ok(responce);
            }
        }

        [HttpPost("AddPerson")]
        public async Task<ActionResult<ServiceResponce<AddPersonDTO>>> AddPerson(AddPersonDTO personDto)
        {
            var responce = await _personService.AddPerson(personDto);
            if (responce == null)
            {
                return BadRequest(responce);
            }
            else
            {
                return Ok(responce);
            }
        }

        [HttpPut("UpdatePerson")]
        public async Task<ActionResult<ServiceResponce<PersonDTO>>> UpdatePerson(PersonDTO personDto)
        {
            var responce = await _personService.UpdatePerson(personDto);
            if (responce.Value is null)
            {
                return NotFound(responce);
            }
            else
            {
                return Ok(responce);
            }
        }

        [HttpDelete("DeletePerson/{id}")]
        public async Task<ActionResult<ServiceResponce<PersonDTO>>> DeletePerson(int id)
        {
            var responce = await _personService.DeletePerson(id);
            if (responce.Value is null)
            {
                return NotFound(responce);
            }
            else
            {
                return Ok(responce);
            }
        }

    }
}
