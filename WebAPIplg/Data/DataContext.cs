using Microsoft.EntityFrameworkCore;
using WebAPIplg.Models;

namespace WebAPIplg.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<Moderator> Moderator { get; set; }

    }
}
