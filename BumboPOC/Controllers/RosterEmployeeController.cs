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
            return View();
        }

        //get all employees from the database
        public IActionResult GetEmployees()
        {
            return View(_MyContext.Employees.ToList());
        }

    }

}
