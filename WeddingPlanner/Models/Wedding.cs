#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.ComponentModel.DataAnnotations;
using static WeddingPlanner.CustomValidators;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }

        [Display(Name = "Wedder One")]
        // It's required by default because it's a non-nullable string.
        // [Required]
        [MinLength(2, ErrorMessage = "length must be more than 1.")]
        public string WedderOne { get; set; }

        [Display(Name = "Wedder Two")]
        [Required]
        [MinLength(2, ErrorMessage = "length must be more than 1.")]
        public string WedderTwo { get; set; }

        [FutureDate]
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /**********************************************************************
        Relationship properties below

        Foreign Keys: id of a different (foreign) model.

        Navigation props:
            data type is a related model
            MUST use .Include for the data to be included (SQL join).
        **********************************************************************/
        public int UserId { get; set; }
        public User? Planner { get; set; }
        public List<UserWeddingGuest> UserWeddingGuests { get; set; } = new List<UserWeddingGuest>();
    }
}