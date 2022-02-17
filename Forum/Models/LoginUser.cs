using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Models
{
    [NotMapped]
    public class LoginUser
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "is required.")]
        [EmailAddress]
        public string LoginEmail { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "is required.")]
        [MinLength(8, ErrorMessage = "must be at least 8 characters")]
        [DataType(DataType.Password)] // auto fills input type attr
        public string LoginPassword { get; set; }
    }
}