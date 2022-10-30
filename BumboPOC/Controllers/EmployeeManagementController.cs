using BumboPOC.Models;
using BumboPOC.Models.DomainModels;
using BumboPOC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BumboPOC.Controllers
{
    public class EmployeeManagementController : Controller
    {
        private readonly MyContext _MyContext;

        public EmployeeManagementController(MyContext myContext)
        {
            _MyContext = myContext;
        }

        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            var employees = from s in _MyContext.Employees
                           select s;
            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(e => e.LastName);
                    break;
                case "Date":
                    employees = employees.OrderBy(e => e.BirthDate);
                    break;
                case "date_desc":
                    employees = employees.OrderByDescending(e => e.BirthDate);
                    break;
                default:
                    employees = employees.OrderBy(e => e.LastName);
                    break;
            }
            return View(await employees.AsNoTracking().ToListAsync());
        }


        public IActionResult Create()
        {
            Employee e = new Employee();
            e.Departments.Add(new Departments());
            e.BirthDate = DateTime.Now.AddYears(-20);
            return View(e);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (employee.CassiereDepartmentEnum)
            {
                employee.Departments.Add(new Departments(employee.Id, DepartmentEnum.Cassiere));
            }
            if (employee.StockersDepartment)
            {
                employee.Departments.Add(new Departments(employee.Id, DepartmentEnum.Stocker));
            }
            if (employee.FreshDepartmentEnum)
            {
                employee.Departments.Add(new Departments(employee.Id, DepartmentEnum.Fresh));
            }
            if (ModelState.IsValid)
            {
                _MyContext.Employees.Add(employee);
                _MyContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(employee);

        }

        
    }
}
