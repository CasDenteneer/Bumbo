using BumboPOC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BumboPOC.Controllers
{
    public class PrognosisController : Controller
    {
        private readonly MyContext _MyContext;
 
        
        public PrognosisController(MyContext myContext)
        {
            _MyContext = myContext;

        }

        // GET: PrognosisController
        public ActionResult Index()
        {

            return View(_MyContext.Prognosis.Where(p => p.Date >= DateTime.Now).ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IFormCollection collection)
        {
            if(collection == null)
            {
                return View();
            }
            return View(_MyContext.Prognosis.ToList());
        }


        // GET: PrognosisController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrognosisController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrognosisController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PrognosisDay prognosis)
        {
            if (ModelState.IsValid)
            {
                prognosis.updatePrognosis();
                // if item can't be added to context (because it already exists) then cancel, date is unique.
                if (_MyContext.Prognosis.Where(p => p.Date.Equals(prognosis.Date)).Count() > 0)
                {
                    return View();
                }
                _MyContext.Prognosis.Add(prognosis);
                _MyContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: PrognosisController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrognosisController/Edit/5
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

        // GET: PrognosisController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrognosisController/Delete/5
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
