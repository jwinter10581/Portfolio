using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class ModelAddViewModel : IValidatableObject
    {
        public IEnumerable<Model> Models { get; set; }
        public IEnumerable<SelectListItem> Makes { get; set; }
        public Model NewModel { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(NewModel.ModelName))
            {
                errors.Add(new ValidationResult("Model Name is required"));
            }
            //else
            //{
            //    foreach (var oldModelName in Models)
            //    {
            //        if (Model.ModelName.ToLower() == oldModel.ModelName.ToLower())
            //        {
            //            errors.Add(new ValidationResult("Model Name already exists in database, please try again."));
            //        }
            //    }
            //}

            return errors;
        }
    }
}