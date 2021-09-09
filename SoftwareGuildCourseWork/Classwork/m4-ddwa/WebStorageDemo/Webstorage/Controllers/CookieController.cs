using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStorage.Models;

namespace WebStorage.Controllers
{
    public class CookieController : Controller
    {

        public ActionResult WriteCookie()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriteCookie(Contact contact)
        {
            HttpCookie myCookie = CreateCookie();
            myCookie["Name"] = contact.Name;
            myCookie["Email"] = contact.Email;

            Response.Cookies.Add(myCookie);
            return RedirectToAction("ReadCookie");
        }

        private const string CookieName = "WebstorageDemoCookie";
        private HttpCookie CreateCookie()
        {
            HttpCookie cookie;

            if (Request.Cookies[CookieName] == null)
            {
                cookie = new HttpCookie(CookieName);
            }
            else
            {
                cookie = Request.Cookies[CookieName];
            }

            cookie.Expires = DateTime.Now.AddDays(7);
            return cookie;
        }

        public ActionResult ReadCookie()
        {
            Contact contact = new Contact();
            var cookie = Request.Cookies[CookieName];

            if (cookie != null)
            {
                contact.Name = cookie["Name"];
                contact.Email = cookie["Email"];
            }
            else
            {
                contact.Name = "No cookie";
            }
            return View(contact);
        }

    }
}
