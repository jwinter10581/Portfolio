using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string RoleName { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeEmail { get; set; } // unofficial foreign key for AspNetUsers

        //public int RoleId { get; set; }
        //public string AspNetId { get; set; }
    }
}
