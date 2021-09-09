using MyFirstMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVCApplication.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.CurrentDateTime = DateTime.Now;
            return View();
        }

        [HttpGet]
        public ActionResult Weather()
        {
            CurrentWeather weather = new CurrentWeather();
            weather.Date = DateTime.Now;
            weather.High = 75;
            weather.Low = 62;
            weather.Description = "Sunny";

            return View(weather);
        }
    }
}