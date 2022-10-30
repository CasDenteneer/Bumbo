
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

            var employeesAll = _MyContext.Employees.Include(e => e.Departments).Where(e => e.Active == true).ToList();
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
                plannedShift.Employee = _MyContext.Employees.Include(e => e.Departments).Where(e => e.Id == plannedShift.EmployeeId).FirstOrDefault();
                plannedShift.PrognosisDay = _MyContext.Prognosis.Find(plannedShift.PrognosisId);
                if (plannedShift.PrognosisDay == null)
                { 
                    PrognosisDay prognosisDay = new PrognosisDay();
                    prognosisDay.AmountOfCustomers = 1000;
                    prognosisDay.AmountOfCollies = 100;
                    prognosisDay.Date = plannedShift.StartTime.Date;
                    plannedShift.PrognosisDay = prognosisDay;

                }


                // Inputted start date and end date are not on the same day as the prognosis so set the date to the prognosis date
                if (plannedShift.StartTime.Date != plannedShift.PrognosisDay.Date)
                {
                    plannedShift.StartTime = plannedShift.PrognosisDay.Date.AddHours(plannedShift.StartTime.Hour);
                }
                if (plannedShift.EndTime.Date != plannedShift.PrognosisDay.Date)
                {
                    plannedShift.EndTime = plannedShift.PrognosisDay.Date.AddHours(plannedShift.EndTime.Hour);
                }




                //check if the endtime is after starttime
                if (plannedShift.EndTime < plannedShift.StartTime)
                {
                    ModelState.AddModelError("EndTime", "Eindtijd moet na starttijd komen.");
                    return View(plannedShift);
                }


                // check if there's any overlapping shifts for the employee on the given day
                var overlappingShifts = _MyContext.PlannedShift.Where(p => p.EmployeeId == plannedShift.EmployeeId && p.StartTime.Date == plannedShift.StartTime.Date).ToList();
                if (overlappingShifts.Count > 0)
                {
                    foreach (var shift in overlappingShifts)
                    {
                        if (plannedShift.StartTime < shift.EndTime && plannedShift.EndTime > shift.StartTime)
                        {
                            ModelState.AddModelError("StartTime", "Medewerker is al ingepland for deze tijden.");
                            ModelState.AddModelError("EndTime", "Medewerker is al ingepland for deze tijden.");
                            return View(plannedShift);
                        }
                        
                    }
                }
                // check if employee is unavailable in unavailable moments 
                var unavailableMoments = _MyContext.UnavailableMoment.Where(u => u.EmployeeId == plannedShift.EmployeeId && u.StartTime.Date == plannedShift.StartTime.Date).ToList();
                if (unavailableMoments.Count > 0)
                {
                    foreach (var moment in unavailableMoments)
                    {
                        if (plannedShift.StartTime < moment.EndTime && plannedShift.EndTime > moment.StartTime)
                        {
                            ModelState.AddModelError("StartTime", "Medewerker is niet beschikbaar voor deze tijd.");
                            ModelState.AddModelError("EndTime", "Medewerker is niet beschikbaar voor deze tijd.");
                            
                            return View(plannedShift);
                        }
                    }
                }

                // start of week, calculated by getting the difference between the date and monday.
                int diff = DayOfWeek.Monday - plannedShift.PrognosisDay.Date.DayOfWeek;
                if (diff > 0)
                    diff -= 7;
                var startOfWeek = plannedShift.PrognosisDay.Date.AddDays(diff);
                // check if the employee has worked too much this week 
                var shiftsThisWeek = _MyContext.PlannedShift.Where(p => p.EmployeeId == plannedShift.EmployeeId && p.StartTime.Date >= startOfWeek && p.StartTime.Date <= startOfWeek.AddDays(6)).ToList();
                if (shiftsThisWeek.Count > 0)
                {
                    double totalHoursThisWeek = 0;
                    foreach (var shift in shiftsThisWeek)
                    {
                        totalHoursThisWeek += (shift.EndTime - shift.StartTime).TotalHours;
                    }
                    if (totalHoursThisWeek + (plannedShift.EndTime - plannedShift.StartTime).TotalHours > plannedShift.Employee.MaxHoursInWeekAllowed)
                    {
                        ModelState.AddModelError("StartTime", "Medewerker heeft al te veel gewerkt deze week.");
                        ModelState.AddModelError("EndTime", "Medewerker heeft al te veel gewerkt deze week.");
                        return View(plannedShift);
                    }
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
