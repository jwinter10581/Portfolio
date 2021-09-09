using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeesController : Controller
    {
        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<EmployeeListViewModel> model = from employee in EmployeeRepository.GetAll()
                                                       join department in DepartmentRepository.GetAll()
                                                       on employee.DepartmentId equals department.DepartmentId
                                                       select new EmployeeListViewModel
                                                       {
                                                           Name = employee.FirstName + " " + employee.LastName,
                                                           Department = department.DepartmentName,
                                                           Phone = employee.Phone,
                                                           EmployeeId = employee.EmployeeId,
                                                       };
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            AddEmployeeViewModel model = new AddEmployeeViewModel();

            model.Departments = GetDepartmentsSelectList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee();
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Phone = model.Phone;
                employee.DepartmentId = model.DepartmentId;

                EmployeeRepository.Add(employee);
            }
            else
            {
                model.Departments = GetDepartmentsSelectList();
                return View(model);
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = EmployeeRepository.Get(id);

            var model = new EditEmployeeViewModel();

            model.FirstName = employee.FirstName;
            model.LastName = employee.LastName;
            model.Phone = employee.Phone;
            model.EmployeeId = employee.EmployeeId;
            model.DepartmentId = employee.DepartmentId;

            model.Departments = GetDepartmentsSelectList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee();
                employee.EmployeeId = model.EmployeeId;
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Phone = model.Phone;
                employee.DepartmentId = model.DepartmentId;

                EmployeeRepository.Edit(employee);
            }
            else
            {
                model.Departments = GetDepartmentsSelectList();
                return View(model);
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete (int id)
        {
            EmployeeRepository.Delete(id);
            return RedirectToAction("List");
        }

        private List<SelectListItem> GetDepartmentsSelectList()
        {
            return (from department in DepartmentRepository.GetAll()
                    select new SelectListItem()
                    {
                        Text = department.DepartmentName,
                        Value = department.DepartmentId.ToString()
                    }).ToList();
        }
    }
}