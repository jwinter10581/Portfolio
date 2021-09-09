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
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentAddVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentAddVM studentVM)
        {
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                { 
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));
                }

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Add(studentVM.Student);

                return RedirectToAction("List");
            }
            else
            {
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                return View(studentVM);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var student = StudentRepository.Get(id);

            var studentVM = new StudentEditVM();

            studentVM.Student.StudentId = student.StudentId;
            studentVM.Student.FirstName = student.FirstName;
            studentVM.Student.LastName = student.LastName;
            studentVM.Student.GPA = student.GPA;
            studentVM.Student.Address = student.Address;
            studentVM.Student.Major = student.Major;
            studentVM.Student.Courses = student.Courses;
            studentVM.SelectedCourseIds = student.Courses.Select(c => c.CourseId).ToList();

            studentVM.SetCourseItems(CourseRepository.GetAll());
            studentVM.SetMajorItems(MajorRepository.GetAll());
            studentVM.SetStateItems(StateRepository.GetAll());
            return View(studentVM);
        }

        [HttpPost]
        public ActionResult Edit(StudentEditVM model)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student();
                student.StudentId = model.Student.StudentId;
                student.FirstName = model.Student.FirstName;
                student.LastName = model.Student.LastName;
                student.GPA = model.Student.GPA;
                student.Address = model.Student.Address;

                student.Major = MajorRepository.Get(model.Student.Major.MajorId);

                student.Courses = new List<Course>();

                foreach (var id in model.SelectedCourseIds)
                {
                    student.Courses.Add(CourseRepository.Get(id));
                }

                StudentRepository.Edit(student);
                StudentRepository.SaveAddress(student.StudentId, student.Address);
                return RedirectToAction("List");
            }
            else
            {
                model.SetCourseItems(CourseRepository.GetAll());
                model.SetMajorItems(MajorRepository.GetAll());
                model.SetStateItems(StateRepository.GetAll());
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            StudentDeleteVM viewModel = new StudentDeleteVM();
            viewModel.Student = StudentRepository.Get(id);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(StudentDeleteVM viewModel)
        {
            StudentRepository.Delete(viewModel.Student.StudentId);
            return RedirectToAction("List");
        }
    }
}