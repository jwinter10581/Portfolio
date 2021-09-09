using GuildCars.Data.Factories;
using GuildCars.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class InventoryController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult New()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Used()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Details(string id)
        {
            if(id is null)
            {
                return RedirectToAction("Index", "Home");
            }

            var repo = VehicleRepositoryFactory.GetRepository();
            var model = repo.GetDetails(id);

            return View(model);
        }
    }
}