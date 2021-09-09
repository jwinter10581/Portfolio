using GuildCars.Data.Factories;
using GuildCars.Models.Tables;
using GuildCars.UI.Models;
using GuildCars.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class SalesController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "sales")]
        public ActionResult Index()
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            var model = repo.GetAll();
            return View(model);
        }

        [Authorize(Roles = "sales")]
        [HttpGet]
        public ActionResult Purchase(string id)
        {
            if (id is null)
            {
                return RedirectToAction("Index", "Sales");
            }

            var model = new PurchaseAddViewModel();
            model.States = new SelectList(StateRepositoryFactory.GetRepository().GetAll(), "StateAbbreviation", "StateName");
            model.PurchaseTypes = new SelectList(PurchaseTypeRepositoryFactory.GetRepository().GetAll(), "PurchaseTypeId", "PurchaseTypeName");
            model.Vehicle = VehicleRepositoryFactory.GetRepository().GetDetails(id);
            model.Purchase = new Purchase();

            return View(model);
        }

        [Authorize(Roles = "sales")]
        [HttpPost]
        public ActionResult Purchase(PurchaseAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Purchase.EmployeeId = EmployeeRepositoryFactory.GetRepository().GetByEmployeeEmail(AuthorizeUtilities.GetEmail(this)).EmployeeId;  // Grabs AspNetUser Id & Converts to Employee ID
                    model.Purchase.EmployeeName = EmployeeRepositoryFactory.GetRepository().GetByEmployeeId(model.Purchase.EmployeeId).EmployeeFirstName;
                    model.Purchase.EmployeeName += " " + EmployeeRepositoryFactory.GetRepository().GetByEmployeeId(model.Purchase.EmployeeId).EmployeeLastName;
                    model.Purchase.VINNumber = model.Vehicle.VINNumber;
                    PurchaseRepositoryFactory.GetRepository().Insert(model.Purchase);
                    VehicleRepositoryFactory.GetRepository().Purchase(model.Vehicle.VINNumber);

                    return RedirectToAction("Index", "Sales");
                }
                catch (Exception ex)
                {
                    throw new Exception("Purchase was unsuccessful.");
                }
            }
            else
            {
                model.States = new SelectList(StateRepositoryFactory.GetRepository().GetAll(), "StateAbbreviation", "StateName");
                model.PurchaseTypes = new SelectList(PurchaseTypeRepositoryFactory.GetRepository().GetAll(), "PurchaseTypeId", "PurchaseTypeName");
                model.Vehicle = VehicleRepositoryFactory.GetRepository().GetDetails(model.Vehicle.VINNumber);
                return View(model);
            }
        }

        //if (Request.IsAuthenticated)
        //{
        //    ViewBag.UserId = AuthorizeUtilities.GetUserId(this);  //Used to pass UserId into objects
        //}
    }
}