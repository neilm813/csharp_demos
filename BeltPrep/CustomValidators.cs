using System;
using System.ComponentModel.DataAnnotations;

namespace BeltPrep
{
    public class CustomValidators
    {
        public class FutureDate : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                // Pass it along to the next check, if there is a [Required]
                // that will catch it.
                if (value == null)
                {
                    return ValidationResult.Success;
                }

                if ((DateTime)value < DateTime.Now)
                {
                    return new ValidationResult("Date must be in the future.");
                }
                return ValidationResult.Success;
            }
        }
    }

}
