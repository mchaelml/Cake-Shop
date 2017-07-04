using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M32COM.Models
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           
            var customer = (Customer) validationContext.ObjectInstance;
            var ageCheck = DateTime.Today.Year - customer.BirthDateTime.Value.Year;
            if ((customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo) && ageCheck <= 100)
            {
                return ValidationResult.Success;
            }if ( customer.BirthDateTime == null)
            {
                return new ValidationResult("Birth Date is required.");
                
            }
            if (ageCheck <= 100)
            {
                return new ValidationResult("Birth Date is out of range.");
            }
            var age = DateTime.Today.Year - customer.BirthDateTime.Value.Year;

            return (age >= 18 && ageCheck <= 100)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old");
        }
    }
}