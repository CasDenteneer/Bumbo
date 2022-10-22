using Microsoft.AspNetCore.Mvc;

namespace BumboPOC.Controllers
{
    public class EmployeeRosterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
