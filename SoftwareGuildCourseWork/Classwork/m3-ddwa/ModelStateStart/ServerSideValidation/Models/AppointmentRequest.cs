using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerSideValidation.Models
{
    public class AppointmentRequest
    {
        public string ClientName { get; set; }
        public DateTime Date { get; set; }
        public bool TermsAccepted { get; set; }
    }
}