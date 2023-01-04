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
    public class BuildSystemsController : Controller
    {
        private readonly EMSContext _context;

        public BuildSystemsController(EMSContext context)
        {
            _context = context;
        }

        // GET: BuildSystems
        public async Task<IActionResult> Index()
        {
            var eMSContext = _context.BuildSystems.Include(b => b.Admin).Include(b => b.Employee);
            return View(await eMSContext.ToListAsync());
        }

        // GET: BuildSystems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BuildSystems == null)
            {
                return NotFound();
            }

            var buildSystem = await _context.BuildSystems
                .Include(b => b.Admin)
                .Include(b => b.Employee)
                .FirstOrDefaultAsync(m => m.BuildID == id);
            if (buildSystem == null)
            {
                return NotFound();
            }

            return View(buildSystem);
        }

        // GET: BuildSystems/Create
        public IActionResult Create()
        {
            ViewData["adminId"] = new SelectList(_context.Admins, "AdminId", "AdminId");
            ViewData["employeeId"] = new SelectList(_context.Employees, "EmployeeID", "Department");
            return View();
        }

        // POST: BuildSystems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BuildID,Name,Surname,SystemName,EmployeeCode,MemorySize,Mouse,Keyboard,Monitor,adminId,employeeId")] BuildSystem buildSystem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buildSystem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["adminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", buildSystem.adminId);
            ViewData["employeeId"] = new SelectList(_context.Employees, "EmployeeID", "Department", buildSystem.employeeId);
            return View(buildSystem);
        }

        // GET: BuildSystems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BuildSystems == null)
            {
                return NotFound();
            }

            var buildSystem = await _context.BuildSystems.FindAsync(id);
            if (buildSystem == null)
            {
                return NotFound();
            }
            ViewData["adminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", buildSystem.adminId);
            ViewData["employeeId"] = new SelectList(_context.Employees, "EmployeeID", "Department", buildSystem.employeeId);
            return View(buildSystem);
        }

        // POST: BuildSystems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BuildID,Name,Surname,SystemName,EmployeeCode,MemorySize,Mouse,Keyboard,Monitor,adminId,employeeId")] BuildSystem buildSystem)
        {
            if (id != buildSystem.BuildID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buildSystem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildSystemExists(buildSystem.BuildID))
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
            ViewData["adminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", buildSystem.adminId);
            ViewData["employeeId"] = new SelectList(_context.Employees, "EmployeeID", "Department", buildSystem.employeeId);
            return View(buildSystem);
        }

        // GET: BuildSystems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BuildSystems == null)
            {
                return NotFound();
            }

            var buildSystem = await _context.BuildSystems
                .Include(b => b.Admin)
                .Include(b => b.Employee)
                .FirstOrDefaultAsync(m => m.BuildID == id);
            if (buildSystem == null)
            {
                return NotFound();
            }

            return View(buildSystem);
        }

        // POST: BuildSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BuildSystems == null)
            {
                return Problem("Entity set 'EMSContext.BuildSystems'  is null.");
            }
            var buildSystem = await _context.BuildSystems.FindAsync(id);
            if (buildSystem != null)
            {
                _context.BuildSystems.Remove(buildSystem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildSystemExists(int id)
        {
          return _context.BuildSystems.Any(e => e.BuildID == id);
        }
    }
}
