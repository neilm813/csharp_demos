using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static WeddingPlanner.CustomValidators;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }

        [Display(Name = "Wedder One")]
        [Required]
        [MinLength(2, ErrorMessage = "length must be more than 1.")]
        public string WedderOne { get; set; } = null!;

        [Display(Name = "Wedder Two")]
        [Required]
        [MinLength(2, ErrorMessage = "length must be more than 1.")]
        public string WedderTwo { get; set; } = null!;

        [FutureDate]
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /**********************************************************************
        Relationship properties below

        Foreign Keys: id of a different (foreign) model.

        Navigation props:
            data type is a related model
            MUST use .Include or else nav props will be null.
        **********************************************************************/
        public int UserId { get; set; }
        public User? Planner { get; set; }
        public List<UserWeddingGuest>? UserWeddingGuests { get; set; }

    }
}