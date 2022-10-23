using BumboPOC.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace BumboPOC.Controllers
{
    public class RosterEmployeeController : Controller
    {
        private readonly MyContext _MyContext;
        public RosterEmployeeController(MyContext myContext)
        {
            _MyContext = myContext;
        }

        public IActionResult Index()
        {
            var _employee = _MyContext.Employees.Where(e => e.Id == 1).FirstOrDefault();
            var _plannedShifts = _MyContext.PlannedShift.Where(s => s.EmployeeId == _employee.Id).ToList();
            return View(_plannedShifts);
        }

    }

}
