using GuildCars.Data.Factories;
using GuildCars.Models.Tables;
using GuildCars.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace GuildCars.UI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.FeaturedVehicles = VehicleRepositoryFactory.GetRepository().GetFeatured();
            model.Specials = SpecialRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Specials()
        {
            var model = SpecialRepositoryFactory.GetRepository().GetAll();

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Contact(String VINNumber)
        {
            var model = new ContactAddViewModel();
            model.Contact = new Contact();
            
            if (VINNumber is null)
            {
                return View(model);
            }
            else
            {
                model.Contact.VINNumber = VINNumber;
                return View(model);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Contact(ContactAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = ContactRepositoryFactory.GetRepository();

                try
                {
                    repo.Insert(model.Contact);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw new Exception("Contact was unsuccessful.");
                }
            }
            else
            {
                return View(model);
            }
        }
    }
}