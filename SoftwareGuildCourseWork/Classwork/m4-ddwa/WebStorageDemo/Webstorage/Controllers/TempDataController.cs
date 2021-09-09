using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStorage.Models;

namespace WebStorage.Controllers
{
    public class TempDataController : Controller
    {
        //
        // GET: /TempData/

        public ActionResult WriteTempData()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriteTempData(Contact contact)
        {
            TempData["ContactInformation"] = contact;
            TempData["SuccessMessage"] = "Great job!";
            return RedirectToAction("ReadTempData");
        }

        public ActionResult ReadTempData()
        {
            Contact contact;

            if (TempData["ContactInformation"] != null)
            {
                contact = (Contact)TempData["ContactInformation"];
            }
            else
            {
                contact = new Contact() { Name = "No TempData!", Email = "Fail!" }; // blank
            }
            return View(contact);
        }

    }
}
