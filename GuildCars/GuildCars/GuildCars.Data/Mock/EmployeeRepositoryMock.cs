using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class EmployeeRepositoryMock : IEmployeeRepository
    {
        private static List<Employee> _employees = new List<Employee> // If sql database is reset or re-seeded, you must update AspNetId
        {
            new Employee
            { EmployeeId = 1, EmployeeFirstName = "System", EmployeeLastName = "Administrator", EmployeeEmail = "admin@guildcars.com", RoleName = "Admin"},
            new Employee
            { EmployeeId = 2, EmployeeFirstName = "Sales", EmployeeLastName = "Person", EmployeeEmail = "sales@guildcars.com", RoleName = "Sales"},
            new Employee
            { EmployeeId = 3, EmployeeFirstName = "Disabled", EmployeeLastName = "User", EmployeeEmail = "disabled@guildcars.com", RoleName = "Disabled"}
        };

        public static void Initialize()
        {
            _employees = new List<Employee>
            {
                new Employee
                { EmployeeId = 1, EmployeeFirstName = "System", EmployeeLastName = "Administrator", EmployeeEmail = "admin@guildcars.com", RoleName = "Admin"},
                new Employee
                { EmployeeId = 2, EmployeeFirstName = "Sales", EmployeeLastName = "Person", EmployeeEmail = "sales@guildcars.com", RoleName = "Sales"},
                new Employee
                { EmployeeId = 3, EmployeeFirstName = "Disabled", EmployeeLastName = "User", EmployeeEmail = "disabled@guildcars.com", RoleName = "Disabled"}
            };
        }

        public List<Employee> GetAll()
        {
            return _employees;
        }

        public Employee GetByEmployeeEmail(string employeeEmail)
        {
            return _employees.FirstOrDefault(a => a.EmployeeEmail == employeeEmail);
        }

        public Employee GetByEmployeeId(int employeeId)
        {
            return _employees.FirstOrDefault(e => e.EmployeeId == employeeId);
        }

        public void Insert(Employee newEmployee)
        {
            if (_employees.Any())
            {
                newEmployee.EmployeeId = _employees.Max(e => e.EmployeeId) + 1;
            }
            else
            {
                newEmployee.EmployeeId = 1;
            }
            _employees.Add(newEmployee);
        }

        public void Update(Employee updatedEmployee)
        {
            var found = _employees.FirstOrDefault(e => e.EmployeeId == updatedEmployee.EmployeeId);

            if (found != null)
            {
                _employees.RemoveAll(e => e.EmployeeId == updatedEmployee.EmployeeId);
                _employees.Add(updatedEmployee);
            }
        }
    }
}
