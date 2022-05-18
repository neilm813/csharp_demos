using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingPlanner
{
    public class CustomValidators
    {
        public class FutureDate : ValidationAttribute
        {
            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                if (value == null)
                {
                    // Pass our validator so it can go to the next validator
                    // b/c we can't check an empty date.
                    return ValidationResult.Success;
                }

                DateTime date = (DateTime)value;

                if (date <= DateTime.Now)
                {
                    return new ValidationResult("must be in the future.");
                }
                return ValidationResult.Success;
            }
        }
    }
}