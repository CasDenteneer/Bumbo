
using BumboPOC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BumboPOC.Controllers
{
    public class RosterController : Controller
    {

        private readonly MyContext _MyContext;

        public RosterController(MyContext myContext)
        {
            _MyContext = myContext;
         
        }
        
        
            // GET: Roster
            public ActionResult Index(string? dateInput)
            {
            if(dateInput == null)
            {
                dateInput = DateTime.Today.ToString();
            }
            DateTime newDate = DateTime.Parse(dateInput);

            PrognosisDay? prognosis = _MyContext.Prognosis.Where(p => p.Date == newDate.Date).FirstOrDefault();

            if (prognosis == null)
            {
                prognosis = new PrognosisDay();
                prognosis.Date = newDate;
                prognosis.AmountOfCollies = 0;
                prognosis.AmountOfCustomers = 0;
            }
            RosterDay roster = new RosterDay(prognosis);

            roster.AvailableEmployees = _MyContext.Employees.ToList();

            return View(roster);
           
        }

       

        // GET: Roster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Roster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roster/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Roster/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Roster/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Roster/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Roster/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
