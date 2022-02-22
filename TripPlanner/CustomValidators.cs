using System;
using System.ComponentModel.DataAnnotations;

namespace TripPlanner
{
    public class FutureDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Because our Date field is optional, can't convert null to date.
            if (value == null)
            {
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