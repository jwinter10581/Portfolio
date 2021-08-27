using GuildCars.Data.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class ReportsController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Inventory()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Sales()
        {
            var repo = EmployeeRepositoryFactory.GetRepository().GetAll().Select(e =>
                new SelectListItem
                {
                    Text = e.EmployeeFirstName + " " + e.EmployeeLastName,
                    Value = e.EmployeeId.ToString()
                });
            return View(repo);
        }
    }
}