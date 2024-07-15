using AutoMapper;
using WebAPIplg.DTO.Person;
using WebAPIplg.Models;

namespace WebAPIplg.Services.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly IMapper _mapper;
        public PersonService(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static readonly List<Person> people = new List<Person>() {
            new Person { Id = 0, FirstName = "Bebro", LastName = "Bebroni" },
            new Person { Id = 1, FirstName = "Denys", LastName = "Fostytskyi" }
        };

        public async Task<ServiceResponce<List<PersonDTO>>> GetAllPeople()
        {
            var serviceResponce = new ServiceResponce<List<PersonDTO>>();
            serviceResponce.Value = people.Select(p => _mapper.Map<PersonDTO>(p)).ToList();

            return serviceResponce;
        }

        public async Task<ServiceResponce<PersonDTO>> GetPersonById(int id)
        {
            var person = people.FirstOrDefault(p => p.Id == id);

            var serviceResponce = new ServiceResponce<PersonDTO>();
            serviceResponce.Value = _mapper.Map<PersonDTO>(person);

            return serviceResponce;
        }

        public async Task<ServiceResponce<PersonDTO>> AddPerson(PersonDTO personDto)
        {
            people.Add(_mapper.Map<Person>(personDto));

            var serviceResponce = new ServiceResponce<PersonDTO>();
            serviceResponce.Value = personDto;

            return serviceResponce;
        }
    }
}
