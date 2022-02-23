using System;
using System.ComponentModel.DataAnnotations;

namespace TripPlanner.Models
{
    /* 
    Many To Many Join table for Many Trip : Many DestinationMedia
    */
    public class TripDestination
    {
        [Key]
        public int TripDestinationId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* Relationships */
        //  Foreign Keys
        public int TripId { get; set; }
        public int DestinationMediaId { get; set; }

        // Navigation Properties (related class instances) - MUST use .Include to access.
        public Trip Trip { get; set; }
        public DestinationMedia Destination { get; set; }

    }
}