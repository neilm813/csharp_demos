using Microsoft.EntityFrameworkCore;

namespace TripPlanner.Models
{
    public class TripPlannerContext : DbContext
    {
        public TripPlannerContext(DbContextOptions options) : base(options) { }

        // for every model / entity that is going to be part of the db
        // the names of these properties will be the names of the tables in the db
        public DbSet<User> Users { get; set; }
    }
}