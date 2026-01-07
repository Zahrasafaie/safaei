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
    public class AboutusController : Controller
    {
        private readonly safaeiContext _context;

        public AboutusController(safaeiContext context)
        {
            _context = context;
        }

        // GET: Admin/Aboutus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aboutus.ToListAsync());
        }

        // GET: Admin/Aboutus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutus = await _context.Aboutus
                .FirstOrDefaultAsync(m => m.AboutusId == id);
            if (aboutus == null)
            {
                return NotFound();
            }

            return View(aboutus);
        }

        // GET: Admin/Aboutus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Aboutus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AboutusId,tell,addrees")] Aboutus aboutus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aboutus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutus);
        }

        // GET: Admin/Aboutus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutus = await _context.Aboutus.FindAsync(id);
            if (aboutus == null)
            {
                return NotFound();
            }
            return View(aboutus);
        }

        // POST: Admin/Aboutus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AboutusId,tell,addrees")] Aboutus aboutus)
        {
            if (id != aboutus.AboutusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aboutus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutusExists(aboutus.AboutusId))
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
            return View(aboutus);
        }

        // GET: Admin/Aboutus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutus = await _context.Aboutus
                .FirstOrDefaultAsync(m => m.AboutusId == id);
            if (aboutus == null)
            {
                return NotFound();
            }

            return View(aboutus);
        }

        // POST: Admin/Aboutus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aboutus = await _context.Aboutus.FindAsync(id);
            if (aboutus != null)
            {
                _context.Aboutus.Remove(aboutus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutusExists(int id)
        {
            return _context.Aboutus.Any(e => e.AboutusId == id);
        }
    }
}
