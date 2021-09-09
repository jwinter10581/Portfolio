using AdvancedModelBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvancedModelBinding.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CheckboxList()
        {
            var model = new CategoryPickerViewModel();

            // convert the list of category objects to CategoryCheckBoxItems using LINQ
            model.CategoryCheckboxes = 
                (from category in CategoryRepository.GetAll()
                 select new CategoryCheckBoxItem { Category = category, IsSelected = false }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult CheckboxList(CategoryPickerViewModel model)
        {
            var selectedIds = 
                model.CategoryCheckboxes.Where(c => c.IsSelected).Select(c => c.Category.CategoryId);
            return View("PickResults", selectedIds);
        }

        [HttpGet]
        public ActionResult CustomModelBinder()
        {
            return View(new BirthdayPerson());
        }

        [HttpPost]
        public ActionResult CustomModelBinder([ModelBinder(typeof(BirthdayPersonBinder))]BirthdayPerson model)
        {
            return View(model);
        }
    }
}