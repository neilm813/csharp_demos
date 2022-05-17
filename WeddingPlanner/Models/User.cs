/* How to disable warning just in specific files.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
*/

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [MinLength(2, ErrorMessage = "must be longer than 1 character.")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        [Required]
        [MinLength(2, ErrorMessage = "must be longer than 1 character.")]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [NotMapped]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "must match password.")]
        public string PasswordConfirm { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        /**********************************************************************
        Relationship properties below

        Foreign Keys: id of a different (foreign) model.

        Navigation props:
            data type is a related model
            MUST use .Include or else nav props will be null.
        **********************************************************************/

        public List<Wedding> PlannedWeddings { get; set; } = null!;
        public List<UserWeddingGuest> UserWeddingGuests { get; set; } = null!;
    }
}