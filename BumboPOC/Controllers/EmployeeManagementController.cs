using BumboPOC.Models;
using BumboPOC.Models.DomainModels;
using BumboPOC.Models.ViewModels;
using BumboPOCData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BumboPOC.Controllers
{
    public class EmployeeManagementController : Controller
    {
        private readonly MyDBContext _MyContext;
        private IBumboEmployee _Employees;

        public EmployeeManagementController(MyDBContext myContext, IBumboEmployee employees)
        {
            _MyContext = myContext;
            _Employees = employees;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            // The list will only show the following items: Name, Department, Function, Region, Employee since, Active based on the use case.

            var employees = from e in _MyContext.Employees
                            select e;
            

            if (!String.IsNullOrEmpty(searchString))
            {
               

                // search in employees if any of the columns contains the searchstring
                
                


            }
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
            List<DepartmentEnum> departments = new List<DepartmentEnum> { DepartmentEnum.Stocker, DepartmentEnum.Fresh, DepartmentEnum.Cassiere };
            ViewData["EmployeeDepartments"] = new SelectList(departments, "Departments", "FirstName");
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
