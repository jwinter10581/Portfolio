using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class VehicleAddViewModel : IValidatableObject
    {
        public IEnumerable<SelectListItem> BodyStyles { get; set; }
        public IEnumerable<SelectListItem> Colors { get; set; }
        public IEnumerable<SelectListItem> Interiors { get; set; }
        public IEnumerable<SelectListItem> Makes { get; set; }
        public IEnumerable<SelectListItem> Models { get; set; }
        public IEnumerable<SelectListItem> Transmissions { get; set; }
        public IEnumerable<SelectListItem> VehicleTypes { get; set; }

        public Vehicle Vehicle { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Vehicle.MakeName))
            {
                errors.Add(new ValidationResult("Make Name is required"));
            }

            if (string.IsNullOrEmpty(Vehicle.ModelName))
            {
                errors.Add(new ValidationResult("Model Name is required"));
            }

            if (Vehicle.Year <= 2000 || Vehicle.Year > DateTime.Now.AddYears(1).Year)
            {
                errors.Add(new ValidationResult("Year must be betweeen 2000 & " + DateTime.Now.AddYears(1).Year));
            }

            if (Vehicle.Mileage <= 0)
            {
                errors.Add(new ValidationResult("Mileage must be greater than 0"));
            }
            else if (Vehicle.Mileage <= 1000)
            {
                if (Vehicle.VehicleTypeName.ToLower() != "new")
                {
                    errors.Add(new ValidationResult("Only new vehicles can have mileage under 1000"));
                }            
            }
            else if (Vehicle.Mileage >= 1000)
            {
                if (Vehicle.VehicleTypeName.ToLower() != "used")
                {
                    errors.Add(new ValidationResult("Only used vehicles can have mileage over 1000"));
                }
            }

            if (string.IsNullOrEmpty(Vehicle.VINNumber))
            {
                errors.Add(new ValidationResult("VIN Number is required"));
            }
            else if (Vehicle.VINNumber.Length != 17)
            {
                errors.Add(new ValidationResult("VIN Numbers are required to be 17 digits"));
            }

            if (Vehicle.MSRP <= 0)
            {
                errors.Add(new ValidationResult("MSRP must be greater than 0"));
            }

            if (Vehicle.SalePrice <= 0)
            {
                errors.Add(new ValidationResult("Sale Price must be greater than 0"));
            }
            else if (Vehicle.SalePrice > Vehicle.MSRP)
            {
                errors.Add(new ValidationResult("Sale Price cannot be greater than MSRP"));
            }

            if (string.IsNullOrEmpty(Vehicle.Description))
            {
                errors.Add(new ValidationResult("Description is required"));
            }

            if (ImageUpload != null && ImageUpload.ContentLength > 0)
            {
                var extensions = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

                var extension = Path.GetExtension(ImageUpload.FileName);

                if (!extensions.Contains(extension))
                {
                    errors.Add(new ValidationResult("Image file must be a jpg, jpeg, png, or gif"));
                }
            }
            else
            {
                errors.Add(new ValidationResult("Image file is required"));
            }

            return errors;
        }
    }
}