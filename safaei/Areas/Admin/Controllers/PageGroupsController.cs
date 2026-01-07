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
    public class PageGroupsController : Controller
    {
        private readonly safaeiContext _context;

        public PageGroupsController(safaeiContext context)
        {
            _context = context;
        }

        // GET: Admin/PageGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.PageGroup.ToListAsync());
        }

        // GET: Admin/PageGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageGroup = await _context.PageGroup
                .FirstOrDefaultAsync(m => m.GroupId == id);
            if (pageGroup == null)
            {
                return NotFound();
            }

            return View(pageGroup);
        }

        // GET: Admin/PageGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PageGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupId,GroupTitle")] PageGroup pageGroup)
        {
            ModelState.Remove("Page");
            if (ModelState.IsValid)
            {
                _context.Add(pageGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pageGroup);
        }

        // GET: Admin/PageGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageGroup = await _context.PageGroup.FindAsync(id);
            if (pageGroup == null)
            {
                return NotFound();
            }
            return View(pageGroup);
        }

        // POST: Admin/PageGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupId,GroupTitle")] PageGroup pageGroup)
        {
            if (id != pageGroup.GroupId)
            {
                return NotFound();
            }
            ModelState.Remove("Page");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pageGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageGroupExists(pageGroup.GroupId))
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
            return View(pageGroup);
        }

        // GET: Admin/PageGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageGroup = await _context.PageGroup
                .FirstOrDefaultAsync(m => m.GroupId == id);
            if (pageGroup == null)
            {
                return NotFound();
            }

            return View(pageGroup);
        }

        // POST: Admin/PageGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pageGroup = await _context.PageGroup.FindAsync(id);
            if (pageGroup != null)
            {
                _context.PageGroup.Remove(pageGroup);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PageGroupExists(int id)
        {
            return _context.PageGroup.Any(e => e.GroupId == id);
        }
    }
}
