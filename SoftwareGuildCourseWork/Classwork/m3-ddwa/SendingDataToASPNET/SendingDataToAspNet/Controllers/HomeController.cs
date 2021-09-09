using SendingDataToAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SendingDataToAspNet.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        #region Passing by Querystring
        /// <summary>
        /// We can use the Request object from the controller base class to 
        /// read in query string values from the dictionary
        /// </summary>
        [HttpGet]
        public ActionResult QueryString1()
        {
            var model = new ProductSearch();

            model.Category = Request.QueryString["category"];
            model.Subcategory = Request.QueryString["subcategory"];

            return View("SearchResult", model);
        }

        /// <summary>
        /// If you name your parameters the same name as the query string parameters,
        /// ASP.NET MVC will automatically copy the data into the method parameters
        /// </summary>
        [HttpGet]
        public ActionResult QueryString2(string category, string subcategory)
        {
            var model = new ProductSearch();

            model.Category = category;
            model.Subcategory = subcategory;

            return View("SearchResult", model);
        }

        /// <summary>
        /// If you use a C# object as your model.  ASP.NET will automatically instantiate it
        /// then scan its properties.  If it finds a property and query string share the same name
        /// it will copy the value into the property automatically
        /// </summary>
        [HttpGet]
        public ActionResult QueryString3(ProductSearch model)
        {
            return View("SearchResult", model);
        }
        #endregion

        #region Passing by Path (RouteConfig)
        /// <summary>
        /// If you declare route segments in the RouteConfig, you can get access to that route 
        /// data via the RouteData object which is a member of the Controller base class
        /// </summary>
        [HttpGet]
        public ActionResult Path1()
        {
            var model = new ProductSearch();

            model.Category = RouteData.Values["category"].ToString();
            model.Subcategory = RouteData.Values["subcategory"].ToString();

            return View("SearchResult", model);
        }

        /// <summary>
        /// If the model binder finds a path segment in the RouteConfig with the same name 
        /// as a parameter it will automatically copy the value in
        /// </summary>
        [HttpGet]
        public ActionResult Path2(string category, string subcategory)
        {
            var model = new ProductSearch();

            model.Category = category;
            model.Subcategory = subcategory;

            return View("SearchResult", model);
        }

        /// <summary>
        /// Again, the model binder will automatically instantiate your object parameter
        /// and attempt to match values from the route data into the properties of the object
        /// </summary>
        [HttpGet]
        public ActionResult Path3(ProductSearch model)
        {
            return View("SearchResult", model);
        }
        #endregion

        #region Passing by Request Body (form post)
        /// <summary>
        /// Values in the Request Body are placed into the Form Dictionary
        /// of the Request object
        /// </summary>
        [HttpPost]
        public ActionResult Form1()
        {
            var model = new ProductSearch();

            model.Category = Request.Form["category"].ToString();
            model.Subcategory = Request.Form["subcategory"].ToString();

            return View("SearchResult", model);
        }

        /// <summary>
        /// If the model binder finds a name value pair in the Request Body with the 
        /// same name as a parameter, it will automatically copy the value in
        /// </summary>
        [HttpPost]
        public ActionResult Form2(string category, string subcategory)
        {
            var model = new ProductSearch();

            model.Category = category;
            model.Subcategory = subcategory;

            return View("SearchResult", model);
        }

        /// <summary>
        /// Again, the model binder will automatically instantiate your object parameter
        /// and attempt to match values from the request body into the properties of the object
        /// </summary>
        [HttpPost]
        public ActionResult Form3(ProductSearch model)
        {
            return View("SearchResult", model);
        }
        #endregion
    }
}