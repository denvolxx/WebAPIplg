using WebAPIplg.DTO.Person;
using WebAPIplg.Models;

namespace WebAPIplg.Services.PersonService
{
    public interface IPersonService
    {
        Task<ServiceResponce<List<PersonDTO>>> GetAllPeople();
        Task<ServiceResponce<PersonDTO>> GetPersonById(int id);
        Task<ServiceResponce<PersonDTO>> AddPerson(PersonDTO personDto);
        Task<ServiceResponce<PersonDTO>> UpdatePerson(PersonDTO personDto);
        Task<ServiceResponce<PersonDTO>> DeletePerson(int id);

    }
}
