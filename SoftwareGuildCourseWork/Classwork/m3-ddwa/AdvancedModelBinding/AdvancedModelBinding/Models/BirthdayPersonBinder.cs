using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvancedModelBinding.Models
{
    public class BirthdayPersonBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, 
            ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;

            var person = new BirthdayPerson();

            person.FirstName = request.Form["FirstName"];
            person.LastName = request.Form["LastName"];

            int month = int.Parse(request.Form["month"]);
            int day = int.Parse(request.Form["day"]);
            int year = int.Parse(request.Form["year"]);

            person.Birthday = new DateTime(year, month, day);

            return person;
        }
    }
}