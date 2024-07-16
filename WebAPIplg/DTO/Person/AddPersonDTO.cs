using WebAPIplg.Models;

namespace WebAPIplg.DTO.Person
{
    public class AddPersonDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender? Gender { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
    }
}
