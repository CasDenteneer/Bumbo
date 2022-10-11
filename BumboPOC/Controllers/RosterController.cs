using BumboPOC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BumboPOC.Controllers
{
    public class RosterController : Controller
    {

        List<PrognosisDay> PrognosisList = new List<PrognosisDay>();

        public RosterController()
        {

            // prognosis test data in region:
            #region

            PrognosisDay prognosis1 = new PrognosisDay(10, 10, new DateTime(2020, 1, 1));
            PrognosisDay prognosis2 = new PrognosisDay(20, 20, new DateTime(2020, 1, 2));
            PrognosisDay prognosis3 = new PrognosisDay(30, 30, new DateTime(2020, 1, 3));
            PrognosisDay prognosis4 = new PrognosisDay(40, 40, new DateTime(2020, 1, 4));
            PrognosisDay prognosis5 = new PrognosisDay(50, 50, new DateTime(2020, 1, 5));


            PrognosisList.Add(prognosis1);
            PrognosisList.Add(prognosis2);
            PrognosisList.Add(prognosis3);
            PrognosisList.Add(prognosis4);
            PrognosisList.Add(prognosis5);
            #endregion
        }
        
        
            // GET: Roster
            public ActionResult Index()
        {
            
            return View(PrognosisList);
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
