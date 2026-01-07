using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using safaei.Data;
using safaei.Models;

namespace safaei.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class contactusController : Controller
    {
        private readonly safaeiContext _context;

        public contactusController(safaeiContext context)
        {
            _context = context;
        }

        // GET: Admin/contactus
        public async Task<IActionResult> Index()
        {
            return View(await _context.contactus.ToListAsync());
        }

        // GET: Admin/contactus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactus = await _context.contactus
                .FirstOrDefaultAsync(m => m.contactId == id);
            if (contactus == null)
            {
                return NotFound();
            }

            return View(contactus);
        }

        // GET: Admin/contactus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/contactus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("contactId,tell,Mobile")] contactus contactus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactus);
        }

        // GET: Admin/contactus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactus = await _context.contactus.FindAsync(id);
            if (contactus == null)
            {
                return NotFound();
            }
            return View(contactus);
        }

        // POST: Admin/contactus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("contactId,tell,Mobile")] contactus contactus)
        {
            if (id != contactus.contactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!contactusExists(contactus.contactId))
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
            return View(contactus);
        }

        // GET: Admin/contactus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactus = await _context.contactus
                .FirstOrDefaultAsync(m => m.contactId == id);
            if (contactus == null)
            {
                return NotFound();
            }

            return View(contactus);
        }

        // POST: Admin/contactus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactus = await _context.contactus.FindAsync(id);
            if (contactus != null)
            {
                _context.contactus.Remove(contactus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool contactusExists(int id)
        {
            return _context.contactus.Any(e => e.contactId == id);
        }
    }
}
