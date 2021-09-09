using MVC_SIS_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MVC_SIS_UI.Models
{
    public class AddEditMajorVM: IValidatableObject
    {
        public Major currentMajor { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (currentMajor == null || currentMajor.MajorName == "" || currentMajor.MajorName == null)
            {
                errors.Add(new ValidationResult("Please enter a Major Name",
                    new[] { "currentMajor.MajorName" }));
            }

            return errors;
        }
    }
}