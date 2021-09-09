using ServerSideValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServerSideValidation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new AppointmentRequest());
        }

        [HttpPost]
        public ActionResult Index(AppointmentRequest model)
        {
            if (string.IsNullOrEmpty(model.ClientName))
            {
                ModelState.AddModelError("ClientName",
                    "Please enter your name");
            }

            if (ModelState.IsValidField("Date"))
            {
                if (model.Date < DateTime.Today.AddDays(1))
                {
                    ModelState.AddModelError("Date",
                        "Appointments cannot be same-day or in the past");
                }
                else if (model.Date.DayOfWeek == DayOfWeek.Saturday || 
                    model.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    ModelState.AddModelError("Date",
                        "We do not accept weekend appointments");
                }
            }
            else
            {
                ModelState.AddModelError("Date", 
                    "Please enter a valid date for the appointment");
            }

            if(!model.TermsAccepted)
            {
                ModelState.AddModelError("TermsAccepted",
                    "You must accept the terms to book an appointment");
            }

            if(ModelState.IsValidField("ClientName") && ModelState.IsValidField("Date"))
            {
                if(model.ClientName == "Garfield" && model.Date.DayOfWeek == DayOfWeek.Monday)
                {
                    ModelState.AddModelError("", "Garfield may not book on Mondays");
                }
            }

            if (ModelState.IsValid)
            {
                // here we would save the appointment to a database
                return View("Confirmation", model);
            }
            else
            {
                // send them back to the entry form
                return View("Index", model);
            }
        }
    }
}