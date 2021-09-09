using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class EmployeeListViewModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public int EmployeeId { get; set; }
    }
}