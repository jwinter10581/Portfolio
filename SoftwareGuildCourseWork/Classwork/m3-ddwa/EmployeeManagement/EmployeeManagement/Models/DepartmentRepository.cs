using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class DepartmentRepository
    {
        private static List<Department> _departments;

        static DepartmentRepository()
        {
            _departments = new List<Department>()
            {
                new Department { DepartmentId = 1, DepartmentName = "Computer Science" },
                new Department { DepartmentId = 2, DepartmentName = "Finance" },
                new Department { DepartmentId = 3, DepartmentName = "Sales" },
            };
        }

        public static List<Department> GetAll()
        {
            return _departments;
        }
    }
}