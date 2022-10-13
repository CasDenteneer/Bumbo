using BumboPOC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BumboPOC.Controllers
{
    public class EmployeeRosterController : Controller
    {
        public EmployeeRosterController()
        {
            
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
