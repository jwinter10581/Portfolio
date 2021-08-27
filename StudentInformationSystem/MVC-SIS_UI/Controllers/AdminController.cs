using MVC_SIS_Data;
using MVC_SIS_Models;
using MVC_SIS_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_SIS_UI.Controllers
{
    public class AdminController : Controller
    {
        #region Major Methods
        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new AddEditMajorVM());
        }

        [HttpPost]
        public ActionResult AddMajor(AddEditMajorVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            MajorRepository.Add(viewModel.currentMajor.MajorName);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            AddEditMajorVM viewmodel = new AddEditMajorVM();
            viewmodel.currentMajor = MajorRepository.Get(id);
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult EditMajor(AddEditMajorVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            MajorRepository.Edit(viewModel.currentMajor);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            DeleteMajorVM viewModel = new DeleteMajorVM();
            viewModel.currentMajor = MajorRepository.Get(id);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeleteMajor(DeleteMajorVM viewModel)
        {
            MajorRepository.Delete(viewModel.currentMajor.MajorId);
            return RedirectToAction("Majors");
        }
        #endregion

        #region State Methods
        [HttpGet]
        public ActionResult States()
        {
            var model = StateRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddState()
        {
            return View(new AddEditStateVM());
        }

        [HttpPost]
        public ActionResult AddState(AddEditStateVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            StateRepository.Add(viewModel.currentState);
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult EditState(string id)
        {
            AddEditStateVM viewmodel = new AddEditStateVM();
            viewmodel.currentState = StateRepository.Get(id);
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult EditState(AddEditStateVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            StateRepository.Edit(viewModel.currentState);
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult DeleteState(string id)
        {
            DeleteStateVM viewModel = new DeleteStateVM();
            viewModel.currentState = StateRepository.Get(id);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeleteState(DeleteStateVM viewModel)
        {
            StateRepository.Delete(viewModel.currentState.StateAbbreviation);
            return RedirectToAction("States");
        }
        #endregion

        #region Course Methods
        [HttpGet]
        public ActionResult Courses()
        {
            var model = CourseRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            return View(new AddEditCourseVM());
        }

        [HttpPost]
        public ActionResult AddCourse(AddEditCourseVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            CourseRepository.Add(viewModel.currentCourse.CourseName);
            return RedirectToAction("Courses");
        }

        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            AddEditCourseVM viewmodel = new AddEditCourseVM();
            viewmodel.currentCourse = CourseRepository.Get(id);
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult EditCourse(AddEditCourseVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            CourseRepository.Edit(viewModel.currentCourse);
            return RedirectToAction("Courses");
        }

        [HttpGet]
        public ActionResult DeleteCourse(int id)
        {
            DeleteCourseVM viewModel = new DeleteCourseVM();
            viewModel.currentCourse = CourseRepository.Get(id);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeleteCourse(DeleteCourseVM viewModel)
        {
            CourseRepository.Delete(viewModel.currentCourse.CourseId);
            return RedirectToAction("Courses");
        }
        #endregion
    }
}