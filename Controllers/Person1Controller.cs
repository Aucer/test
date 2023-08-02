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
    public class Person1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Person1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Person1
        public async Task<IActionResult> Index()
        {
              return _context.Person1 != null ? 
                          View(await _context.Person1.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Person1'  is null.");
        }

        // GET: Person1/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Person1 == null)
            {
                return NotFound();
            }

            var person1 = await _context.Person1
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (person1 == null)
            {
                return NotFound();
            }

            return View(person1);
        }

        // GET: Person1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Person1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,PersonName")] Person1 person1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person1);
        }

        // GET: Person1/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Person1 == null)
            {
                return NotFound();
            }

            var person1 = await _context.Person1.FindAsync(id);
            if (person1 == null)
            {
                return NotFound();
            }
            return View(person1);
        }

        // POST: Person1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonID,PersonName")] Person1 person1)
        {
            if (id != person1.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Person1Exists(person1.PersonID))
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
            return View(person1);
        }

        // GET: Person1/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Person1 == null)
            {
                return NotFound();
            }

            var person1 = await _context.Person1
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (person1 == null)
            {
                return NotFound();
            }

            return View(person1);
        }

        // POST: Person1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Person1 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Person1'  is null.");
            }
            var person1 = await _context.Person1.FindAsync(id);
            if (person1 != null)
            {
                _context.Person1.Remove(person1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Person1Exists(string id)
        {
          return (_context.Person1?.Any(e => e.PersonID == id)).GetValueOrDefault();
        }
    }
}
