using Microsoft.EntityFrameworkCore;

namespace Forum.Models
{
    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions options) : base(options) { }

        // for every model / entity that is going to be part of the db
        // the names of these properties will be the names of the tables in the db
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
