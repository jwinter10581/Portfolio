using RazorAndHtmlHelpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorAndHtmlHelpers.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Students()
        {
            List<Student> allStudents = StudentRepository.GetStudents();

            return View(allStudents);
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            // create an empty student object
            Student model = new Student();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddStudent(Student model)
        {
            // here we would save our model to a database
            return View(model);
        }
    }
}