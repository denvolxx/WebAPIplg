using WebAPIplg.Models;

namespace WebAPIplg.Services.PersonService
{
    public interface IPersonService
    {
        Task<ServiceResponce<List<Person>>> GetAllPeople();
        Task<ServiceResponce<Person>> GetPersonById(int id);
        Task<ServiceResponce<Person>> AddPerson(Person person);

    }
}
