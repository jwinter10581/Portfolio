using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class AddEmployeeViewModel
    {
        [Required(ErrorMessage = "Please enter a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName { get; set; }

        public string Phone { get; set; }

        public int DepartmentId { get; set; }


        public List<SelectListItem> Departments { get; set; }
    }
}