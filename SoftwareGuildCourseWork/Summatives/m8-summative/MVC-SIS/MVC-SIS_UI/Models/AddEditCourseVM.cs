using MVC_SIS_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_SIS_UI.Models
{
    public class AddEditCourseVM: IValidatableObject
    {
        public Course currentCourse { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (currentCourse == null || currentCourse.CourseName == "" || currentCourse.CourseName == null)
            {
                errors.Add(new ValidationResult("Please enter a Course Name",
                    new[] { "currentCourse.CourseName" }));
            }

            return errors;
        }
    }
}