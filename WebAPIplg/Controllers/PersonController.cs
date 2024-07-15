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

        [HttpGet("GetAll", Order = 0)]
        public async Task<ActionResult<ServiceResponce<List<PersonDTO>>>> GetAll()
        {
            return Ok(await _personService.GetAllPeople());
        }

        [HttpGet("Get/{id}", Order = 1)]
        public async Task<ActionResult<ServiceResponce<PersonDTO>>> Get(int id)
        {
            return Ok(await _personService.GetPersonById(id));
        }

        [HttpPost("AddPerson")]
        public async Task<ActionResult<ServiceResponce<PersonDTO>>> AddPerson(PersonDTO personDto)
        {
            return Ok(await _personService.AddPerson(personDto));
        }
    }
}
