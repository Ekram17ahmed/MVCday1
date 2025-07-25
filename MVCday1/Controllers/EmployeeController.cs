using Microsoft.AspNetCore.Mvc;
using MVCday1.DataBase;
using MVCday1.DTO;
using MVCday1.Models;

namespace MVCday1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        public EmployeeController()
        {
            applicationDbContext = new ApplicationDbContext();
        }

        public IActionResult Index()
        {
            var result = applicationDbContext.Employees.Where(a=>a.isDeleted==false).ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            var employee = applicationDbContext.Employees.Where(a => a.Id == id).FirstOrDefault();
            if (employee == null)
            {
                ViewBag.Message = "Employee not found";
                return View();
            }
            else
            {
                EmployeeDTO employeeDTO = new()
                {

                    Name = employee.Name,
                    Age = employee.Age,
                    Salary = employee.Salary,
                    DeptId = employee.DeptID,
                    Id = employee.Id
                };
                return View(employeeDTO);
            }
             
        }
        public IActionResult SaveEmployee(EmployeeDTO emp)
        {
            if (emp.Name != null && emp.Age != 0 && emp.Salary != 10)
            {
                var employee = new Employee(emp.Name, emp.Age, emp.Salary, "By Ekram Auf");
                applicationDbContext.Employees.Add(employee);
                applicationDbContext.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            return View("Create", emp);
        }
        //public IActionResult Edit(int id)
        //{
        //    var employee = applicationDbContext.Employees.Where(a => a.Id == id).FirstOrDefault();
        //    EmployeeDTO employeeDTO = new()
        //    {

        //        Name = employee.Name,
        //        Age = employee.Age,
        //        Salary = employee.Salary,
        //        DeptId = employee.DeptID,
        //        Id = employee.Id
        //    };
        //    return View(employeeDTO);
        //}
        public IActionResult EditEmployee(EmployeeDTO emp)
        {
            if (emp.Id == 0)
            {
                ViewBag.ErrorMessage = "Employee not found";
                return View("Edit", emp);
            }
                

            var employee = applicationDbContext.Employees.Where(a => a.Id == emp.Id).FirstOrDefault();

            employee.Edit(emp.Name, emp.Salary, emp.Age);
            applicationDbContext.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }
        public IActionResult GetEmployee(int id)
        {
            var employee = applicationDbContext.Employees.Where(a => a.Id == id).FirstOrDefault();
            if (employee == null)
            {
                ViewBag.Message = "Employee not found";
                return View();
            }
            else
            {
                EmployeeDTO employeeDTO = new()
                {

                    Name = employee.Name,
                    Age = employee.Age,
                    Salary = employee.Salary,
                    DeptId = employee.DeptID,
                    Id = employee.Id
                };
                return View(employeeDTO);
            }
        }

        public IActionResult Delete(int id)
        {
            var employee = applicationDbContext.Employees.Where(a => a.Id == id).FirstOrDefault();
            employee.Delete();
            applicationDbContext.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }
    }
}
