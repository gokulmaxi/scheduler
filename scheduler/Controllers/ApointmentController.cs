using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using scheduler.Areas.Identity.Data;
using scheduler.Data;
using scheduler.Models;

namespace scheduler.Controllers
{
    public class ApointmentController : Controller
    {
        private readonly schedulerContext _context;
        private UserManager<schedulerUser> _userManager;
        public ApointmentController(schedulerContext context,UserManager<schedulerUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Apointment
        public async Task<IActionResult> Index()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userID = await _userManager.GetUserAsync(User);
            Console.WriteLine("Hello"+userID.Id);
            return _context.ApointmentModel != null ?
                        View(await _context.ApointmentModel
                        .Where(s=> s.UserId == userID)
                        .ToListAsync()) :
                        Problem("Entity set 'schedulerContext.ApointmentModel'  is null.");
        }

        // GET: Apointment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ApointmentModel == null)
            {
                return NotFound();
            }

            var apointmentModel = await _context.ApointmentModel
                .FirstOrDefaultAsync(m => m.ApointmentId == id);
            if (apointmentModel == null)
            {
                return NotFound();
            }

            return View(apointmentModel);
        }

        // GET: Apointment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Apointment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApointmentId,ApointmentName,StartDateTime,EndDateTime")] ApointmentModel apointmentModel)
        {
            apointmentModel.UserId = _context.Users.First();
                Console.WriteLine(apointmentModel.ApointmentId);
                _context.Add(apointmentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: Apointment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ApointmentModel == null)
            {
                return NotFound();
            }

            var apointmentModel = await _context.ApointmentModel.FindAsync(id);
            if (apointmentModel == null)
            {
                return NotFound();
            }
            return View(apointmentModel);
        }

        // POST: Apointment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApointmentId,ApointmentName,StartDateTime,EndDateTime")] ApointmentModel apointmentModel)
        {
            if (id != apointmentModel.ApointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apointmentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApointmentModelExists(apointmentModel.ApointmentId))
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
            return View(apointmentModel);
        }

        // GET: Apointment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ApointmentModel == null)
            {
                return NotFound();
            }

            var apointmentModel = await _context.ApointmentModel
                .FirstOrDefaultAsync(m => m.ApointmentId == id);
            if (apointmentModel == null)
            {
                return NotFound();
            }

            return View(apointmentModel);
        }

        // POST: Apointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ApointmentModel == null)
            {
                return Problem("Entity set 'schedulerContext.ApointmentModel'  is null.");
            }
            var apointmentModel = await _context.ApointmentModel.FindAsync(id);
            if (apointmentModel != null)
            {
                _context.ApointmentModel.Remove(apointmentModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApointmentModelExists(int id)
        {
            return (_context.ApointmentModel?.Any(e => e.ApointmentId == id)).GetValueOrDefault();
        }
    }
}
