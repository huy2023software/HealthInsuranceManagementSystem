using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace HealthInsuranceManagementSystem.Models
{
    public class NotInFutureAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime joinDate = (DateTime)value;

                if (joinDate.Date > DateTime.Now.Date)
                    return new ValidationResult("Join date can't be a day " +
                        "in the future");
            }

            return ValidationResult.Success;
        }
    }
}