using WebAPIplg.DTO.Person;
using WebAPIplg.Models;

namespace WebAPIplg.Services.PersonService
{
    public interface IPersonService
    {
        Task<ServiceResponce<List<PersonDTO>>> GetAllPeople();
        Task<ServiceResponce<List<PersonDTO>>> GetSubordinates(Guid moderatorId);
        Task<ServiceResponce<PersonDTO>> GetPersonById(int id);
        Task<ServiceResponce<AddPersonDTO>> AddPerson(AddPersonDTO addPersonDto);
        Task<ServiceResponce<PersonDTO>> UpdatePerson(PersonDTO personDto);
        Task<ServiceResponce<PersonDTO>> DeletePerson(int id);

    }
}
