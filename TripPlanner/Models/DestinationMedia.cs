using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TripPlanner.Models
{

    public class DestinationMedia
    {
        public int DestinationMediaId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "must be at least 2 characters.")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Media Url")]
        public string Src { get; set; }

        [Required]
        [Display(Name = "Short Description")]
        [MinLength(4, ErrorMessage = "must be at least 4 characters.")]
        [MaxLength(255, ErrorMessage = "must be no more than 255 characters.")]
        public string ShortDescription { get; set; }

        [Required]
        // Image, Youtube Video Embed, Google Map Embed, Site Embed
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* Relationships */
        //  Foreign Keys
        public int UserId { get; set; }

        // Navigation Properties (related class instances) - MUST use .Include to access.
        public User CreatedBy { get; set; } // 1 User : Many Destinations submitted.
        public List<TripDestination> TripDestinations { get; set; } // This destination can be related to many Trips (Many to Many)
    }
}