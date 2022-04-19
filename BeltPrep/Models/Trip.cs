using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeltPrep.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }

        [Display(Name = "Departure Date")]
        [DataType(DataType.DateTime)]
        public DateTime DepartureDate { get; set; }

        [Display(Name = "Return Date")]
        [DataType(DataType.DateTime)]
        public DateTime ReturnDate { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters.")]
        public string Location { get; set; }

        [Display(Name = "Image Url")]
        public string ImgUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* 
        Relationships and navigation properties. Navigation properties are the
        properties that have another model as their data type.
        
        Navigation properties will be null unless you use .Include
        */

        // 1 User : Many Trip for creating trips.
        public int UserId { get; set; }
        public User Planner { get; set; }

        // Many User to Many Trip for attending trips.
        public List<TripUserJoin> TripUserJoins { get; set; }
    }
}