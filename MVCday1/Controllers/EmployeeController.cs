using Microsoft.AspNetCore.Mvc;
using MVCday1.DataBase;
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
            var result = applicationDbContext.Employees.ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult SaveEmployee(Employee emp)
        {
            if (emp.Name != null && emp.Age != 0 && emp.Salary != 10)
            {
                var employee = new Employee(emp.Name, emp.Age, emp.Salary, "By Ekram Auf");
                applicationDbContext.Employees.Add(employee);
                applicationDbContext.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }
    }
}
