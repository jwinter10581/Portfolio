using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using WebStorage.Models;

namespace WebStorage.Controllers
{
    public class CacheController : Controller
    {
        //
        // GET: /Cache/
        public ActionResult ReadCache()
        {
            List<Contact> contacts;

            if (HttpRuntime.Cache["ContactList"] == null)
            {
                // pretend this is loading from a database
                contacts = new List<Contact>
                {
                    new Contact() { Email = "joe@schmoe.com", Name = "Joe"},
                    new Contact() { Email = "eric@swcguild.com", Name="Eric"}
                };

                HttpRuntime.Cache.Insert("ContactList", contacts, null,
                    DateTime.Now.AddHours(8), Cache.NoSlidingExpiration);
            }
            else
            {
                contacts = (List<Contact>)HttpRuntime.Cache["ContactList"];
            }

            return View(contacts);
        }

        [OutputCache(Duration = 30)]
        public ActionResult OutputCache()
        {
            ViewBag.CurrentDateTime = DateTime.Now.ToString();
            return View();
        }

    }
}
