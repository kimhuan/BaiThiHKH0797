using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiThiHKH.Data;
using BaiThiHKH.Models;

namespace BaiThiHKH.Controllers
{
    public class HKHcau3Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public HKHcau3Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HKHcau3
        public async Task<IActionResult> Index()
        {
              return _context.HKHcau3 != null ? 
                          View(await _context.HKHcau3.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.HKHcau3'  is null.");
        }

        // GET: HKHcau3/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HKHcau3 == null)
            {
                return NotFound();
            }

            var hKHcau3 = await _context.HKHcau3
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (hKHcau3 == null)
            {
                return NotFound();
            }

            return View(hKHcau3);
        }

        // GET: HKHcau3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HKHcau3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,PersonName,PersonNumber,PersonAddress")] HKHcau3 hKHcau3)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hKHcau3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hKHcau3);
        }

        // GET: HKHcau3/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HKHcau3 == null)
            {
                return NotFound();
            }

            var hKHcau3 = await _context.HKHcau3.FindAsync(id);
            if (hKHcau3 == null)
            {
                return NotFound();
            }
            return View(hKHcau3);
        }

        // POST: HKHcau3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("PersonID,PersonName,PersonNumber,PersonAddress")] HKHcau3 hKHcau3)
        {
            if (id != hKHcau3.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hKHcau3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HKHcau3Exists(hKHcau3.PersonID))
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
            return View(hKHcau3);
        }

        // GET: HKHcau3/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HKHcau3 == null)
            {
                return NotFound();
            }

            var hKHcau3 = await _context.HKHcau3
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (hKHcau3 == null)
            {
                return NotFound();
            }

            return View(hKHcau3);
        }

        // POST: HKHcau3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.HKHcau3 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HKHcau3'  is null.");
            }
            var hKHcau3 = await _context.HKHcau3.FindAsync(id);
            if (hKHcau3 != null)
            {
                _context.HKHcau3.Remove(hKHcau3);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HKHcau3Exists(int? id)
        {
          return (_context.HKHcau3?.Any(e => e.PersonID == id)).GetValueOrDefault();
        }
    }
}
