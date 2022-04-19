using System;
using System.ComponentModel.DataAnnotations;

namespace BeltPrep.Models
{
    public class TripUserJoin // many to many 'join' table
    {
        [Key] // denotes PK, not needed if named ModelNameId
        public int TripUserJoinId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* 
        Relationships and navigation properties. Navigation properties are the
        properties that have another model as their data type.
        
        Navigation properties will be null unless you use .Include
        */
        public int UserId { get; set; }
        public User User { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }
    }
}