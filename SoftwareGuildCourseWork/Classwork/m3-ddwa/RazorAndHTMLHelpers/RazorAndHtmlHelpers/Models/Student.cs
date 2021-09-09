using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorAndHtmlHelpers.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Major { get; set; }
        public decimal? GPA { get; set; }
    }

    public class StudentRepository
    {
        public static List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student { FirstName="Joe", LastName="Schmoe", Major="Business", GPA=3.5M },
                new Student { FirstName="Jane", LastName="Doe", Major="Computer Science", GPA=3.8M },
                new Student { FirstName="Mary", LastName="Watts", Major="English", GPA=3.2M }
            };
        }
    }
}