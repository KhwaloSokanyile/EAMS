using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Controllers
{
    public class ReturnedSystemsController : Controller
    {
        private readonly EMSContext _context;

        public ReturnedSystemsController(EMSContext context)
        {
            _context = context;
        }

        // GET: ReturnedSystems
        public async Task<IActionResult> Index()
        {
            var eMSContext = _context.ReturnedSystems.Include(r => r.Admin).Include(r => r.BuildSystem).Include(r => r.Employee);
            return View(await eMSContext.ToListAsync());
        }

        // GET: ReturnedSystems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReturnedSystems == null)
            {
                return NotFound();
            }

            var returnedSystem = await _context.ReturnedSystems
                .Include(r => r.Admin)
                .Include(r => r.BuildSystem)
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(m => m.ReturnId == id);
            if (returnedSystem == null)
            {
                return NotFound();
            }

            return View(returnedSystem);
        }

        // GET: ReturnedSystems/Create
        public IActionResult Create()
        {
            ViewData["adminId"] = new SelectList(_context.Admins, "AdminId", "AdminId");
            ViewData["buildsystemId"] = new SelectList(_context.BuildSystems, "BuildID", "BuildID");
            ViewData["employeeId"] = new SelectList(_context.Employees, "EmployeeID", "Department");
            return View();
        }

        // POST: ReturnedSystems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReturnId,Name,Surname,EmployeeCode,Date,SystemName,Comments,adminId,employeeId,buildsystemId")] ReturnedSystem returnedSystem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(returnedSystem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["adminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", returnedSystem.adminId);
            ViewData["buildsystemId"] = new SelectList(_context.BuildSystems, "BuildID", "BuildID", returnedSystem.buildsystemId);
            ViewData["employeeId"] = new SelectList(_context.Employees, "EmployeeID", "Department", returnedSystem.employeeId);
            return View(returnedSystem);
        }

        // GET: ReturnedSystems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReturnedSystems == null)
            {
                return NotFound();
            }

            var returnedSystem = await _context.ReturnedSystems.FindAsync(id);
            if (returnedSystem == null)
            {
                return NotFound();
            }
            ViewData["adminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", returnedSystem.adminId);
            ViewData["buildsystemId"] = new SelectList(_context.BuildSystems, "BuildID", "BuildID", returnedSystem.buildsystemId);
            ViewData["employeeId"] = new SelectList(_context.Employees, "EmployeeID", "Department", returnedSystem.employeeId);
            return View(returnedSystem);
        }

        // POST: ReturnedSystems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReturnId,Name,Surname,EmployeeCode,Date,SystemName,Comments,adminId,employeeId,buildsystemId")] ReturnedSystem returnedSystem)
        {
            if (id != returnedSystem.ReturnId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(returnedSystem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReturnedSystemExists(returnedSystem.ReturnId))
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
            ViewData["adminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", returnedSystem.adminId);
            ViewData["buildsystemId"] = new SelectList(_context.BuildSystems, "BuildID", "BuildID", returnedSystem.buildsystemId);
            ViewData["employeeId"] = new SelectList(_context.Employees, "EmployeeID", "Department", returnedSystem.employeeId);
            return View(returnedSystem);
        }

        // GET: ReturnedSystems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReturnedSystems == null)
            {
                return NotFound();
            }

            var returnedSystem = await _context.ReturnedSystems
                .Include(r => r.Admin)
                .Include(r => r.BuildSystem)
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(m => m.ReturnId == id);
            if (returnedSystem == null)
            {
                return NotFound();
            }

            return View(returnedSystem);
        }

        // POST: ReturnedSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReturnedSystems == null)
            {
                return Problem("Entity set 'EMSContext.ReturnedSystems'  is null.");
            }
            var returnedSystem = await _context.ReturnedSystems.FindAsync(id);
            if (returnedSystem != null)
            {
                _context.ReturnedSystems.Remove(returnedSystem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReturnedSystemExists(int id)
        {
          return _context.ReturnedSystems.Any(e => e.ReturnId == id);
        }
    }
}
