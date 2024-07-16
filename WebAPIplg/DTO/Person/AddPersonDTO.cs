using WebAPIplg.Models;

namespace WebAPIplg.DTO.Person
{
    public class AddPersonDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender? Gender { get; set; }
    }
}
