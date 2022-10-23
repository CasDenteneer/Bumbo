using BumboPOC.Models.DomainModels;
using BumboPOC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BumboPOC.Controllers
{
    public class EmployeeRosterController : Controller
    {
        private readonly MyContext _MyContext;
        public EmployeeRosterController(MyContext myContext)
        {
            _MyContext = myContext;
        }

        public IActionResult Index()
        {
            var _employee = _MyContext.Employees.Where(e => e.Id == 1).FirstOrDefault();
            var _plannedShifts = _MyContext.PlannedShift.Where(s => s.EmployeeId == _employee.Id).ToList();

            var _employeeShiftsViewModel = new EmployeeShiftsViewModel();
            _employeeShiftsViewModel.Employee = _employee;
            _employeeShiftsViewModel.PlannedShifts = _plannedShifts;

            return View(_employeeShiftsViewModel);
        }

    }

}