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
    public class AssignedTicketsController : Controller
    {
        private readonly EMSContext _context;

        public AssignedTicketsController(EMSContext context)
        {
            _context = context;
        }

        // GET: AssignedTickets
        public async Task<IActionResult> Index()
        {
            var eMSContext = _context.AssignedTickets.Include(a => a.Admin).Include(a => a.Ticket);
            return View(await eMSContext.ToListAsync());
        }

        // GET: AssignedTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AssignedTickets == null)
            {
                return NotFound();
            }

            var assignedTicket = await _context.AssignedTickets
                .Include(a => a.Admin)
                .Include(a => a.Ticket)
                .FirstOrDefaultAsync(m => m.AssignedTicketsId == id);
            if (assignedTicket == null)
            {
                return NotFound();
            }

            return View(assignedTicket);
        }

        // GET: AssignedTickets/Create
        public IActionResult Create()
        {
            ViewData["adminId"] = new SelectList(_context.Admins, "AdminId", "AdminId");
            ViewData["ticketId"] = new SelectList(_context.Tickets, "TickectID", "TickectID");
            return View();
        }

        // POST: AssignedTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssignedTicketsId,Date,Name,EmployeeCode,Priority,adminId,ticketId")] AssignedTicket assignedTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignedTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["adminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", assignedTicket.adminId);
            ViewData["ticketId"] = new SelectList(_context.Tickets, "TickectID", "TickectID", assignedTicket.ticketId);
            return View(assignedTicket);
        }

        // GET: AssignedTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AssignedTickets == null)
            {
                return NotFound();
            }

            var assignedTicket = await _context.AssignedTickets.FindAsync(id);
            if (assignedTicket == null)
            {
                return NotFound();
            }
            ViewData["adminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", assignedTicket.adminId);
            ViewData["ticketId"] = new SelectList(_context.Tickets, "TickectID", "TickectID", assignedTicket.ticketId);
            return View(assignedTicket);
        }

        // POST: AssignedTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssignedTicketsId,Date,Name,EmployeeCode,Priority,adminId,ticketId")] AssignedTicket assignedTicket)
        {
            if (id != assignedTicket.AssignedTicketsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignedTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignedTicketExists(assignedTicket.AssignedTicketsId))
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
            ViewData["adminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", assignedTicket.adminId);
            ViewData["ticketId"] = new SelectList(_context.Tickets, "TickectID", "TickectID", assignedTicket.ticketId);
            return View(assignedTicket);
        }

        // GET: AssignedTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AssignedTickets == null)
            {
                return NotFound();
            }

            var assignedTicket = await _context.AssignedTickets
                .Include(a => a.Admin)
                .Include(a => a.Ticket)
                .FirstOrDefaultAsync(m => m.AssignedTicketsId == id);
            if (assignedTicket == null)
            {
                return NotFound();
            }

            return View(assignedTicket);
        }

        // POST: AssignedTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AssignedTickets == null)
            {
                return Problem("Entity set 'EMSContext.AssignedTickets'  is null.");
            }
            var assignedTicket = await _context.AssignedTickets.FindAsync(id);
            if (assignedTicket != null)
            {
                _context.AssignedTickets.Remove(assignedTicket);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignedTicketExists(int id)
        {
          return _context.AssignedTickets.Any(e => e.AssignedTicketsId == id);
        }
    }
}
