using Microsoft.EntityFrameworkCore;

namespace BeltPrep.Models
{
    public class BeltPrepContext : DbContext
    {
        public BeltPrepContext(DbContextOptions options) : base(options) { }

        // for every model / entity that is going to be part of the db
        // the names of these properties will be the names of the tables in the db
        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripUserJoin> TripUserJoins { get; set; }


    }
}
