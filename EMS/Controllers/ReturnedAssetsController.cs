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
    public class ReturnedAssetsController : Controller
    {
        private readonly EMSContext _context;

        public ReturnedAssetsController(EMSContext context)
        {
            _context = context;
        }

        // GET: ReturnedAssets
        public async Task<IActionResult> Index()
        {
            var eMSContext = _context.ReturnedAssets.Include(r => r.Admin).Include(r => r.Asset).Include(r => r.Employee);
            return View(await eMSContext.ToListAsync());
        }

        // GET: ReturnedAssets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReturnedAssets == null)
            {
                return NotFound();
            }

            var returnedAsset = await _context.ReturnedAssets
                .Include(r => r.Admin)
                .Include(r => r.Asset)
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(m => m.ReturnID == id);
            if (returnedAsset == null)
            {
                return NotFound();
            }

            return View(returnedAsset);
        }

        // GET: ReturnedAssets/Create
        public IActionResult Create()
        {
            ViewData["adminId"] = new SelectList(_context.Admins, "AdminId", "AdminId");
            ViewData["assetId"] = new SelectList(_context.Assets, "AssetId", "AssetId");
            ViewData["employeeId"] = new SelectList(_context.Employees, "EmployeeID", "Department");
            return View();
        }

        // POST: ReturnedAssets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReturnID,Name,Surname,EmployeeCode,Date,AssetType,Comments,adminId,employeeId,assetId")] ReturnedAsset returnedAsset)
        {
            if (ModelState.IsValid)
            {
                _context.Add(returnedAsset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["adminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", returnedAsset.adminId);
            ViewData["assetId"] = new SelectList(_context.Assets, "AssetId", "AssetId", returnedAsset.assetId);
            ViewData["employeeId"] = new SelectList(_context.Employees, "EmployeeID", "Department", returnedAsset.employeeId);
            return View(returnedAsset);
        }

        // GET: ReturnedAssets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReturnedAssets == null)
            {
                return NotFound();
            }

            var returnedAsset = await _context.ReturnedAssets.FindAsync(id);
            if (returnedAsset == null)
            {
                return NotFound();
            }
            ViewData["adminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", returnedAsset.adminId);
            ViewData["assetId"] = new SelectList(_context.Assets, "AssetId", "AssetId", returnedAsset.assetId);
            ViewData["employeeId"] = new SelectList(_context.Employees, "EmployeeID", "Department", returnedAsset.employeeId);
            return View(returnedAsset);
        }

        // POST: ReturnedAssets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReturnID,Name,Surname,EmployeeCode,Date,AssetType,Comments,adminId,employeeId,assetId")] ReturnedAsset returnedAsset)
        {
            if (id != returnedAsset.ReturnID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(returnedAsset);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReturnedAssetExists(returnedAsset.ReturnID))
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
            ViewData["adminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", returnedAsset.adminId);
            ViewData["assetId"] = new SelectList(_context.Assets, "AssetId", "AssetId", returnedAsset.assetId);
            ViewData["employeeId"] = new SelectList(_context.Employees, "EmployeeID", "Department", returnedAsset.employeeId);
            return View(returnedAsset);
        }

        // GET: ReturnedAssets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReturnedAssets == null)
            {
                return NotFound();
            }

            var returnedAsset = await _context.ReturnedAssets
                .Include(r => r.Admin)
                .Include(r => r.Asset)
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(m => m.ReturnID == id);
            if (returnedAsset == null)
            {
                return NotFound();
            }

            return View(returnedAsset);
        }

        // POST: ReturnedAssets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReturnedAssets == null)
            {
                return Problem("Entity set 'EMSContext.ReturnedAssets'  is null.");
            }
            var returnedAsset = await _context.ReturnedAssets.FindAsync(id);
            if (returnedAsset != null)
            {
                _context.ReturnedAssets.Remove(returnedAsset);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReturnedAssetExists(int id)
        {
          return _context.ReturnedAssets.Any(e => e.ReturnID == id);
        }
    }
}
