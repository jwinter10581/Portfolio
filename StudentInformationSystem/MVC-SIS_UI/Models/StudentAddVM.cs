using MVC_SIS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_SIS_UI.Models
{
    public class StudentAddVM : IValidatableObject
    {
        public Student Student { get; set; }
        public List<SelectListItem> CourseItems { get; set; }
        public List<SelectListItem> MajorItems { get; set; }
        public List<SelectListItem> StateItems { get; set; }
        public List<int> SelectedCourseIds { get; set; }

        public StudentAddVM()
        {
            CourseItems = new List<SelectListItem>();
            MajorItems = new List<SelectListItem>();
            StateItems = new List<SelectListItem>();
            SelectedCourseIds = new List<int>();
            Student = new Student();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (String.IsNullOrEmpty(Student.FirstName))
            {
                errors.Add(new ValidationResult("Please enter the student's first name",
                    new[] { "Student.FirstName" }));
            }

            if (String.IsNullOrEmpty(Student.LastName))
            {
                errors.Add(new ValidationResult("Please enter the student's last name",
                    new[] { "Student.LastName" }));
            }

            if (Student.GPA == null)
            {
                errors.Add(new ValidationResult("Please enter the student's GPA",
                    new[] { "Student.GPA" }));
            }
            else if (Student.GPA < 0 || Student.GPA > 4)
            {
                errors.Add(new ValidationResult("Please enter a GPA between 0.0 and 4.0",
                    new[] { "Student.GPA" }));
            }

            if (Student.Major.MajorId == 0)
            {
                errors.Add(new ValidationResult("Please select the student's major",
                    new[] { "Student.Major.MajorId" }));
            }
            return errors;
        }


        public void SetCourseItems(IEnumerable<Course> courses)
        {
            foreach (var course in courses)
            {
                CourseItems.Add(new SelectListItem()
                {
                    Value = course.CourseId.ToString(),
                    Text = course.CourseName
                });
            }
        }

        public void SetMajorItems(IEnumerable<Major> majors)
        {
            MajorItems.Add(new SelectListItem()
            {
                Value = "0",
                Text ="-Please Select-"
            });

            foreach (var major in majors)
            {
                MajorItems.Add(new SelectListItem()
                {
                    Value = major.MajorId.ToString(),
                    Text = major.MajorName
                });
            }
        }

        public void SetStateItems(IEnumerable<State> states)
        {
            foreach (var state in states)
            {
                StateItems.Add(new SelectListItem()
                {
                    Value = state.StateAbbreviation,
                    Text = state.StateName
                });
            }
        }
    }
}