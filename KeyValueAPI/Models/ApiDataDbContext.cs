using System.Data.Entity;

namespace KeyValueAPI.Models
{
    public class ApiDataDbContext:DbContext
    {
        public DbSet<data> data { get; set; }
    }
}
