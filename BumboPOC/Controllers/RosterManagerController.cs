
using BumboPOC.Models;
using BumboPOC.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.Linq;
using System.Numerics;

namespace BumboPOC.Controllers
{
    public class RosterManagerController : Controller
    {

        private readonly MyContext _MyContext;

        public RosterManagerController(MyContext myContext)
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

            PrognosisDay? prognosis = _MyContext.Prognosis.Include(p => p.PlannedShiftsOnDay).ThenInclude(p => p.Employee).ThenInclude(e => e.Departments).Where(p => p.Date == newDate.Date).FirstOrDefault();
            if (prognosis == null)
            {
                prognosis = new PrognosisDay();
                prognosis.Date = newDate;
                prognosis.AmountOfCollies = 0;
                prognosis.AmountOfCustomers = 0;
            }
            RosterDay roster = new RosterDay(prognosis);

            roster.UnavailableMomentsOnDay = _MyContext.UnavailableMoment.Where(u => u.StartTime.Date == newDate).Include(u => u.Employee).ToList();

            var employeesAll = _MyContext.Employees.Include(e => e.Departments).ToList();
            roster.AvailableEmployees = employeesAll;




            return View(roster);
           
        }

       

        // GET: Roster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Roster/Create
        public ActionResult Create(int employeeId, int prognosisId, string dateInput)
        {
            PlannedShift plannedShift = new PlannedShift();
            try
            {
                plannedShift.Employee = _MyContext.Employees.Include(e => e.Departments).Where(e => e.Id == employeeId).FirstOrDefault();
                plannedShift.PrognosisDay = _MyContext.Prognosis.Find(prognosisId);
                if (plannedShift.PrognosisDay == null)
                {
                    PrognosisDay prognosisDay = new PrognosisDay();
                    prognosisDay.AmountOfCustomers = 1000;
                    prognosisDay.AmountOfCollies = 100;
                    prognosisDay.Date = DateTime.Parse(dateInput);
                    plannedShift.PrognosisDay = prognosisDay;
                }
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
                if (plannedShift.PrognosisDay == null)
                { 
                    PrognosisDay prognosisDay = new PrognosisDay();
                    prognosisDay.AmountOfCustomers = 1000;
                    prognosisDay.AmountOfCollies = 100;
                    prognosisDay.Date = plannedShift.StartTime.Date;
                    plannedShift.PrognosisDay = prognosisDay;

                }
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
