/* 
Disabled since every DBSet would end with `= null!` otherwise and they aren't
nullable since Entity Framework will at least instantiate an empty list.
*/
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Models
{
    public class WeddingPlannerContext : DbContext
    {
        public WeddingPlannerContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<UserWeddingGuest> UserWeddingGuests { get; set; }

    }
}