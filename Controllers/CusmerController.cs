using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;

namespace test.Controllers
{
    public class CusmerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CusmerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cusmer
        public async Task<IActionResult> Index()
        {
              return _context.Cusmer != null ? 
                          View(await _context.Cusmer.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Cusmer'  is null.");
        }

        // GET: Cusmer/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Cusmer == null)
            {
                return NotFound();
            }

            var cusmer = await _context.Cusmer
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (cusmer == null)
            {
                return NotFound();
            }

            return View(cusmer);
        }

        // GET: Cusmer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cusmer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CusmerID,CusmerName,PersonID,PersonName")] Cusmer cusmer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cusmer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cusmer);
        }

        // GET: Cusmer/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Cusmer == null)
            {
                return NotFound();
            }

            var cusmer = await _context.Cusmer.FindAsync(id);
            if (cusmer == null)
            {
                return NotFound();
            }
            return View(cusmer);
        }

        // POST: Cusmer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CusmerID,CusmerName,PersonID,PersonName")] Cusmer cusmer)
        {
            if (id != cusmer.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cusmer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CusmerExists(cusmer.PersonID))
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
            return View(cusmer);
        }

        // GET: Cusmer/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Cusmer == null)
            {
                return NotFound();
            }

            var cusmer = await _context.Cusmer
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (cusmer == null)
            {
                return NotFound();
            }

            return View(cusmer);
        }

        // POST: Cusmer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Cusmer == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cusmer'  is null.");
            }
            var cusmer = await _context.Cusmer.FindAsync(id);
            if (cusmer != null)
            {
                _context.Cusmer.Remove(cusmer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CusmerExists(string id)
        {
          return (_context.Cusmer?.Any(e => e.PersonID == id)).GetValueOrDefault();
        }
    }
}
