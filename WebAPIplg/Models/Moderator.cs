namespace WebAPIplg.Models
{
    public class Moderator
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = [];
        public byte[] PasswordSalt { get; set; } = [];
        public List<Queue>? Queues { get; set; }
        public List<Person>? Subordinates { get; set; }
    }
}
