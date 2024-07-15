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
            var serviceResponce = new ServiceResponce<PersonDTO>();
            var person = people.FirstOrDefault(p => p.Id == id);

            serviceResponce.Value = _mapper.Map<PersonDTO>(person);

            return serviceResponce;
        }

        public async Task<ServiceResponce<PersonDTO>> AddPerson(PersonDTO personDto)
        {
            var serviceResponce = new ServiceResponce<PersonDTO>();

            people.Add(_mapper.Map<Person>(personDto));

            serviceResponce.Value = personDto;

            return serviceResponce;
        }

        public async Task<ServiceResponce<PersonDTO>> UpdatePerson(PersonDTO personDto)
        {
            var serviceResponce = new ServiceResponce<PersonDTO>();
            try
            {
                var person = people.FirstOrDefault(p => p.Id == personDto.Id);
                if (person == null)
                    throw new Exception($"Character was not found");

                _mapper.Map(personDto, person);

                serviceResponce.Value = personDto;
            }
            catch (Exception ex)
            {
                serviceResponce.Success = false;
                serviceResponce.Message = ex.Message;
            }

            return serviceResponce;
        }

        public async Task<ServiceResponce<PersonDTO>> DeletePerson(int id)
        {
            var serviceResponce = new ServiceResponce<PersonDTO>();

            try
            {
                var person = people.FirstOrDefault(p => p.Id == id);
                if (person == null)
                    throw new Exception($"Character was not found");

                people.Remove(person);

                serviceResponce.Value = _mapper.Map<PersonDTO>(person);
            }
            catch (Exception ex)
            {
                serviceResponce.Success = false;
                serviceResponce.Message = ex.Message;
            }

            return serviceResponce;
        }
    }
}
