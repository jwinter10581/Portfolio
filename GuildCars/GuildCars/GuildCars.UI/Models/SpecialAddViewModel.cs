using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class SpecialAddViewModel : IValidatableObject
    {
        public IEnumerable<Special> Specials { get; set; }
        public Special Special { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Special.Title))
            {
                errors.Add(new ValidationResult("Model Name is required"));
            }

            if (string.IsNullOrEmpty(Special.Description))
            {
                errors.Add(new ValidationResult("Model Name is required"));
            }

            return errors;
        }
    }
}