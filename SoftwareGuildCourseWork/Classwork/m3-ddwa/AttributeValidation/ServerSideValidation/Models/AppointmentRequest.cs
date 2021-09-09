using ServerSideValidation.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace ServerSideValidation.Models
{
    [NoGarfieldMondays(ErrorMessage = "Garfield cannot book appointments on Mondays")]
    public class AppointmentRequest
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "You must enter a date")]
        [FutureDate(ErrorMessage = "You must book an appointment in the future")]
        [NoWeekends(ErrorMessage = "You cannot book appointments on the weekend")]
        public DateTime Date { get; set; }

        [MustBeTrue(ErrorMessage = "You must accept the terms to book an appointment")]
        public bool TermsAccepted { get; set; }
    }
}

