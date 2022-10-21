using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BumboPOC.Models.DomainModels;

namespace BumboPOC.Controllers
{
    public class EmployeeAvailabilityController : Controller
    {
        private readonly MyContext _context;

        public EmployeeAvailabilityController(MyContext context)
        {
            _context = context;
        }

        // GET: EmployeeAvailability
        public async Task<IActionResult> Index()
        {
            var myContext = _context.UnavailableMoment.Include(u => u.Employee);
            return View(await myContext.ToListAsync());
        }

        // GET: EmployeeAvailability/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UnavailableMoment == null)
            {
                return NotFound();
            }

            var unavailableMoment = await _context.UnavailableMoment
                .Include(u => u.Employee)
                .FirstOrDefaultAsync(m => m.UnavailableMomentId == id);
            if (unavailableMoment == null)
            {
                return NotFound();
            }

            return View(unavailableMoment);
        }

        // GET: EmployeeAvailability/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName");
           
            return View();
        }

        // POST: EmployeeAvailability/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnavailableMomentId,EmployeeId,StartTime,EndTime,IsAccountedForInWorkLoad")] UnavailableMoment unavailableMoment)
        {
            
           unavailableMoment.Employee = _context.Employees.Find(unavailableMoment.EmployeeId);
            ModelState.Clear();
           if (ModelState.IsValid)
           {
                _context.Add(unavailableMoment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", unavailableMoment.EmployeeId);
            return View(unavailableMoment);
        }

        // GET: EmployeeAvailability/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UnavailableMoment == null)
            {
                return NotFound();
            }

            var unavailableMoment = await _context.UnavailableMoment.FindAsync(id);
            if (unavailableMoment == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", unavailableMoment.EmployeeId);
            return View(unavailableMoment);
        }

        // POST: EmployeeAvailability/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnavailableMomentId,EmployeeId,StartTime,EndTime,IsAccountedForInWorkLoad")] UnavailableMoment unavailableMoment)
        {
            if (id != unavailableMoment.UnavailableMomentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unavailableMoment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnavailableMomentExists(unavailableMoment.UnavailableMomentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "BankNumber", unavailableMoment.EmployeeId);
            return View(unavailableMoment);
        }

        // GET: EmployeeAvailability/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UnavailableMoment == null)
            {
                return NotFound();
            }

            var unavailableMoment = await _context.UnavailableMoment
                .Include(u => u.Employee)
                .FirstOrDefaultAsync(m => m.UnavailableMomentId == id);
            if (unavailableMoment == null)
            {
                return NotFound();
            }

            return View(unavailableMoment);
        }

        // POST: EmployeeAvailability/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UnavailableMoment == null)
            {
                return Problem("Entity set 'MyContext.UnavailableMoment'  is null.");
            }
            var unavailableMoment = await _context.UnavailableMoment.FindAsync(id);
            if (unavailableMoment != null)
            {
                _context.UnavailableMoment.Remove(unavailableMoment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnavailableMomentExists(int id)
        {
          return _context.UnavailableMoment.Any(e => e.UnavailableMomentId == id);
        }
    }
}
