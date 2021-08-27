using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        Employee GetByEmployeeId(int employeeId);
        Employee GetByEmployeeEmail(string employeeEmail);
        void Insert(Employee newEmployee);
        void Update(Employee updatedEmployee);
    }
}
