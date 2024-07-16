namespace WebAPIplg.Models
{
    public class Queue
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Moderator? Moderator { get; set; }
    }
}
