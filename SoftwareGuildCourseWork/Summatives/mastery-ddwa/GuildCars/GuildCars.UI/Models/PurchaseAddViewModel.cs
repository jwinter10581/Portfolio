using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class PurchaseAddViewModel : IValidatableObject
    {
        public VehicleDetailItem Vehicle { get; set; }
        public Purchase Purchase { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<SelectListItem> PurchaseTypes { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Purchase.Name))
            {
                errors.Add(new ValidationResult("Name is required"));
            }

            if (string.IsNullOrEmpty(Purchase.Phone) && string.IsNullOrEmpty(Purchase.Email))
            {
                errors.Add(new ValidationResult("A phone number or an email is required"));
            }

            if (string.IsNullOrEmpty(Purchase.Street1))
            {
                errors.Add(new ValidationResult("Street 1 is required"));
            }

            if (string.IsNullOrEmpty(Purchase.City))
            {
                errors.Add(new ValidationResult("City is required"));
            }

            if (string.IsNullOrEmpty(Purchase.ZipCode))
            {
                errors.Add(new ValidationResult("Zip Code is required"));
            }
            else if (Purchase.ZipCode.Length != 5)
            {
                errors.Add(new ValidationResult("Please enter a 5 digit zip code"));
            }

            if (Purchase.PurchasePrice < Decimal.Multiply(Vehicle.SalePrice, .95M))
            {
                errors.Add(new ValidationResult("Purchase Price cannot be less than 95% of the sale price, which is: " + Decimal.Multiply(Vehicle.SalePrice, .95M)));
            }

            if (Purchase.PurchasePrice > Vehicle.MSRP)
            {
                errors.Add(new ValidationResult("Purchase Price cannot exceed the MSRP"));
            }

            return errors;
        }
    }
}