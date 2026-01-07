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
    public class PagesController : Controller
    {
        private readonly safaeiContext _context;

        public PagesController(safaeiContext context)
        {
            _context = context;
        }

        // GET: Admin/Pages
        public async Task<IActionResult> Index()
        {
            var safaeiContext = _context.Page.Include(p => p.PageGroup);
            return View(await safaeiContext.ToListAsync());
        }

        // GET: Admin/Pages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.Page
                .Include(p => p.PageGroup)
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // GET: Admin/Pages/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.PageGroup, "GroupId", "GroupTitle");
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PageId,GroupId,Title,ShortDescription,Text,Visit,ShowInSlider,ImageName,CreatDate")] Page page, IFormFile imgUp)
        {
            ModelState.Remove("PageGroup");
            ModelState.Remove("Comment");
            ModelState.Remove("ImageName");

            if (ModelState.IsValid)
            {
                page.Visit = 0;
                page.CreatDate = DateTime.Now;
                page.ImageName = "no-photo.jpeg";

                if (imgUp != null)
                {
                    page.ImageName = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Pages", page.ImageName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        imgUp.CopyTo(stream);
                    }
                }

                _context.Add(page);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.PageGroup, "GroupId", "GroupTitle", page.GroupId);
            return View(page);
        }

        // GET: Admin/Pages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.Page.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.PageGroup, "GroupId", "GroupTitle", page.GroupId);
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PageId,GroupId,Title,ShortDescription,Text,Visit,ShowInSlider,ImageName,CreatDate")] Page page, IFormFile imgUp)
        {
            if (id != page.PageId)
            {
                return NotFound();
            }

            ModelState.Remove("PageGroup");
            ModelState.Remove("Comment");
            ModelState.Remove("ImageName");

            if (ModelState.IsValid)
            {
                try
                {
                    page.CreatDate = DateTime.Now;



                    if (imgUp != null)
                    {
                        string deieteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Pages", page.ImageName);
                        if(System.IO.File.Exists(deieteImagePath))
                        {
                            System.IO.File.Delete(deieteImagePath);
                        }
                        page.ImageName = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                        string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Pages", page.ImageName);
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            imgUp.CopyTo(stream);
                        }
                    }
                    _context.Update(page);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageExists(page.PageId))
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
            ViewData["GroupId"] = new SelectList(_context.PageGroup, "GroupId", "GroupTitle", page.GroupId);
            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.Page
                .Include(p => p.PageGroup)
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var page = await _context.Page.FindAsync(id);
            if (page != null)
            {
                if(page.ImageName!="no-photo.jpeg")
                {
                    string deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Pages", page.ImageName);
                    if (System.IO.File.Exists(deleteImagePath))
                    {
                        System.IO.File.Delete(deleteImagePath);
                    }
                }
                _context.Page.Remove(page);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PageExists(int id)
        {
            return _context.Page.Any(e => e.PageId == id);
        }
    }
}
