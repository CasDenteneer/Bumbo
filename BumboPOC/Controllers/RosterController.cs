
using BumboPOC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.Linq;
using System.Numerics;

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
            var employeesAll = _MyContext.Employees.Include(e => e.Departments).ToList();
            roster.AvailableEmployees = employeesAll;

            // get the employees that have been scheduled on the day already
            roster.AssignedEmployees = _MyContext.Employees.Include(e => e.PlannedShifts).ToList();
            
            return View(roster);
           
        }

       

        // GET: Roster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Roster/Create
        public ActionResult Create(int employeeId, int prognosisId)
        {
            PlannedShift plannedShift = new PlannedShift();
            try
            {
                plannedShift.Employee = _MyContext.Employees.Find(employeeId);
                plannedShift.PrognosisDay = _MyContext.Prognosis.Find(prognosisId);
                plannedShift.StartTime = plannedShift.PrognosisDay.Date.AddHours(8);
                plannedShift.EndTime = plannedShift.StartTime.Date.AddHours(14);
                plannedShift.EmployeeId = employeeId;
                plannedShift.PrognosisId = prognosisId;
            }
            catch
            {
                return NotFound();
            }
            return View(plannedShift);
        }

        // POST: Roster/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlannedShift plannedShift)
        {
            try
            {
                plannedShift.Employee = _MyContext.Employees.Find(plannedShift.EmployeeId);
                plannedShift.PrognosisDay = _MyContext.Prognosis.Find(plannedShift.PrognosisId);
                _MyContext.PlannedShift.Add(plannedShift);
                _MyContext.SaveChanges();
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
