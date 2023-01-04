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
    public class ResolvedTicketsController : Controller
    {
        private readonly EMSContext _context;

        public ResolvedTicketsController(EMSContext context)
        {
            _context = context;
        }

        // GET: ResolvedTickets
        public async Task<IActionResult> Index()
        {
            var eMSContext = _context.ResolvedTickets.Include(r => r.Admin).Include(r => r.Ticket);
            return View(await eMSContext.ToListAsync());
        }

        // GET: ResolvedTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ResolvedTickets == null)
            {
                return NotFound();
            }

            var resolvedTicket = await _context.ResolvedTickets
                .Include(r => r.Admin)
                .Include(r => r.Ticket)
                .FirstOrDefaultAsync(m => m.ResolveTickectID == id);
            if (resolvedTicket == null)
            {
                return NotFound();
            }

            return View(resolvedTicket);
        }

        // GET: ResolvedTickets/Create
        public IActionResult Create()
        {
            ViewData["adminId"] = new SelectList(_context.Admins, "AdminId", "AdminId");
            ViewData["ticketId"] = new SelectList(_context.Tickets, "TickectID", "TickectID");
            return View();
        }

        // POST: ResolvedTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResolveTickectID,Name,Surname,EmployeeCode,Date,Resolved,adminId,ticketId")] ResolvedTicket resolvedTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resolvedTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["adminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", resolvedTicket.adminId);
            ViewData["ticketId"] = new SelectList(_context.Tickets, "TickectID", "TickectID", resolvedTicket.ticketId);
            return View(resolvedTicket);
        }

        // GET: ResolvedTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ResolvedTickets == null)
            {
                return NotFound();
            }

            var resolvedTicket = await _context.ResolvedTickets.FindAsync(id);
            if (resolvedTicket == null)
            {
                return NotFound();
            }
            ViewData["adminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", resolvedTicket.adminId);
            ViewData["ticketId"] = new SelectList(_context.Tickets, "TickectID", "TickectID", resolvedTicket.ticketId);
            return View(resolvedTicket);
        }

        // POST: ResolvedTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResolveTickectID,Name,Surname,EmployeeCode,Date,Resolved,adminId,ticketId")] ResolvedTicket resolvedTicket)
        {
            if (id != resolvedTicket.ResolveTickectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resolvedTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResolvedTicketExists(resolvedTicket.ResolveTickectID))
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
            ViewData["adminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", resolvedTicket.adminId);
            ViewData["ticketId"] = new SelectList(_context.Tickets, "TickectID", "TickectID", resolvedTicket.ticketId);
            return View(resolvedTicket);
        }

        // GET: ResolvedTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ResolvedTickets == null)
            {
                return NotFound();
            }

            var resolvedTicket = await _context.ResolvedTickets
                .Include(r => r.Admin)
                .Include(r => r.Ticket)
                .FirstOrDefaultAsync(m => m.ResolveTickectID == id);
            if (resolvedTicket == null)
            {
                return NotFound();
            }

            return View(resolvedTicket);
        }

        // POST: ResolvedTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ResolvedTickets == null)
            {
                return Problem("Entity set 'EMSContext.ResolvedTickets'  is null.");
            }
            var resolvedTicket = await _context.ResolvedTickets.FindAsync(id);
            if (resolvedTicket != null)
            {
                _context.ResolvedTickets.Remove(resolvedTicket);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResolvedTicketExists(int id)
        {
          return _context.ResolvedTickets.Any(e => e.ResolveTickectID == id);
        }
    }
}
