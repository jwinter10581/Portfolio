using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStorage.Models;

namespace WebStorage.Controllers
{
    public class SessionController : Controller
    {
        //
        // GET: /Session/

        public ActionResult WriteSession()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriteSession(Contact contact)
        {
            Session["ContactInformation"] = contact;
            return RedirectToAction("ReadSession");
        }

        public ActionResult ReadSession()
        {
            Contact contact;

            if (Session["ContactInformation"] != null)
            {
                contact = (Contact) Session["ContactInformation"];
            }
            else
            {
                contact = new Contact() {Name = "No Session!", Email = "Fail!"}; // blank
            }
            return View(contact);
        }

    }
}
