using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class ContactAddViewModel : IValidatableObject
    {
        public Contact Contact { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Contact.Name))
            {
                errors.Add(new ValidationResult("Name is required"));
            }

            if (string.IsNullOrEmpty(Contact.Phone) && string.IsNullOrEmpty(Contact.Email))
            {
                errors.Add(new ValidationResult("A phone number or an email is required"));
            }

            if (string.IsNullOrEmpty(Contact.Message))
            {
                errors.Add(new ValidationResult("Message is required"));
            }

            return errors;
        }
    }
}