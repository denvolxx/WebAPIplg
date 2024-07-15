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
            return Ok(await _personService.GetAllPeople());
        }

        [HttpGet("GetPerson/{id}")]
        public async Task<ActionResult<ServiceResponce<PersonDTO>>> GetPerson(int id)
        {
            return Ok(await _personService.GetPersonById(id));
        }

        [HttpPost("AddPerson")]
        public async Task<ActionResult<ServiceResponce<PersonDTO>>> AddPerson(PersonDTO personDto)
        {
            return Ok(await _personService.AddPerson(personDto));
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
                return Ok();
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
                return Ok();
            }
        }

    }
}
