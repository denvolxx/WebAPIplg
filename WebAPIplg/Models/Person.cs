namespace WebAPIplg.Models
{
    public class Person
    {
        public Person() { }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender? Gender { get; set; }
        public Moderator? Moderator { get; set; }

    }
}
