using WebAPIplg.Models;

namespace WebAPIplg.Services.PersonService
{
    public class PersonService : IPersonService
    {
        public PersonService()
        {
        }

        private static readonly List<Person> people = new List<Person>() {
            new Person { Id = 1, FirstName = "Bebro", LastName = "Bebroni" },
            new Person { Id = 2, FirstName = "Denys", LastName = "Fostytskyi" }
        };

        public async Task<ServiceResponce<List<Person>>> GetAllPeople()
        {
            var serviceResponce = new ServiceResponce<List<Person>>() { Value = people };

            return serviceResponce;
        }

        public async Task<ServiceResponce<Person>> GetPersonById(int id)
        {
            var person = people.FirstOrDefault(p => p.Id == id);
            var serviceResponce = new ServiceResponce<Person>() { Value = person };

            return serviceResponce;
        }

        public async Task<ServiceResponce<Person>> AddPerson(Person person)
        {
            people.Add(person);
            var serviceResponce = new ServiceResponce<Person>() { Value = person };

            return serviceResponce;
        }
    }
}
