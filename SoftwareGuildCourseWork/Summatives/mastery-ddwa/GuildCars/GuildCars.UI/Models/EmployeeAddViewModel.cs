using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class EmployeeAddViewModel : IValidatableObject
    {
        public Employee Employee { get; set; }
        public string ConfirmPassword { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Employee.EmployeeFirstName))
            {
                errors.Add(new ValidationResult("First Name is required"));
            }

            if (string.IsNullOrEmpty(Employee.EmployeeLastName))
            {
                errors.Add(new ValidationResult("Last Name is required"));
            }

            if (string.IsNullOrEmpty(Employee.EmployeeEmail))
            {
                errors.Add(new ValidationResult("Email is required"));
            }

            if (string.IsNullOrEmpty(Employee.Password))
            {
                errors.Add(new ValidationResult("Password is required"));
            }

            if (string.IsNullOrEmpty(ConfirmPassword))
            {
                errors.Add(new ValidationResult("Confirm Password is required"));
            }
            else if (ConfirmPassword != Employee.Password)
            {
                errors.Add(new ValidationResult("Password and Confirm Password must match"));
            }

            return errors;
        }
    }
}