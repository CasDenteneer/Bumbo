using BumboPOC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BumboPOC.Controllers
{
    public class EmployeeManagementController : Controller
    {
        private readonly MyContext _MyContext;

        public EmployeeManagementController(MyContext myContext)
        {
            _MyContext = myContext;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            Employee e = new Employee();
            e.Departments.Add(new Departments());
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
