using System;
using System.ComponentModel.DataAnnotations;

namespace TripPlanner.Models
{
    public class Trip
    {
        public int TripId { get; set; }

        [Required]
        /* 
        {0} will insert the property name into the error message, {1} inserts 
        the min length value.
        */
        [MinLength(2, ErrorMessage = "must be at least {1} characters.")]
        public string Name { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "must be at least 10 characters.")]
        public string Description { get; set; }

        [Display(Name = "Trip Date")]
        [DataType(DataType.Date)]
        [FutureDate] // See CustomValidators.cs
        public DateTime? Date { get; set; } // Future only validation
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        /* Relationships */
        //  Foreign Keys
        public int UserId { get; set; }

        // Navigation Properties (related class instances) - MUST use .Include to access.
        public User CreatedBy { get; set; }
    }
}