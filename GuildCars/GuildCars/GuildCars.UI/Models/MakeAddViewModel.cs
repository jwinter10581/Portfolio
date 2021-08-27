using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class MakeAddViewModel : IValidatableObject
    {
        public IEnumerable<Make> Makes { get; set; }
        public Make NewMake { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(NewMake.MakeName))
            {
                errors.Add(new ValidationResult("Make Name is required"));
            }
            //else
            //{
            //    foreach (var oldMakeName in Makes)
            //    {
            //        if (NewMake.MakeName.ToLower() == oldMakeName.MakeName.ToLower())
            //        {
            //            errors.Add(new ValidationResult("Make Name already exists in database, please try again."));
            //        }
            //    }
            //}

            return errors;
        }
    }
}