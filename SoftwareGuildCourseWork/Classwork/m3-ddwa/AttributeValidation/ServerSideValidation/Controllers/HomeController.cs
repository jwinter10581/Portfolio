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
            if (ModelState.IsValid)
            {
                // here we would save the appointment to a database
                return View("Confirmation", model);
            }
            else
            {
                return View("Index", model);
            }
        }
    }
}