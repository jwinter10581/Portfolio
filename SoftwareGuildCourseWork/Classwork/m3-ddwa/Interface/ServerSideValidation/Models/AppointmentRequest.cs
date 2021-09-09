using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServerSideValidation.Models
{
    public class AppointmentRequest : IValidatableObject
    {
        public string ClientName { get; set; }
        public DateTime Date { get; set; }
        public bool TermsAccepted { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(ClientName))
            {
                errors.Add(new ValidationResult("Please enter your name",
                    new[] { "ClientName" }));
            }

            if (DateTime.Today.AddDays(1) > Date)
            {
                errors.Add(new ValidationResult("Please enter a date in the future",
                    new[] { "Date" }));
            }
            else
            {
                if (Date.DayOfWeek == DayOfWeek.Saturday || 
                    Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    errors.Add(new ValidationResult("You cannot book appointments on the weekend",
                        new[] { "Date" }));
                }
            }

            if (errors.Count == 0 && ClientName == "Garfield" && 
                Date.DayOfWeek == DayOfWeek.Monday)
            {
                errors.Add(new ValidationResult("Garfield cannot book appointments on Mondays"));
            }

            if (!TermsAccepted)
            {
                errors.Add(new ValidationResult("You must accept the terms",
                    new[] { "TermsAccepted" }));
            }

            return errors;
        }
    }
}