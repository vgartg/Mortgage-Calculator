using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstWebProject.Data;
using FirstWebProject.Models;

namespace FirstWebProject.Controllers
{
    public class ProcentBasesController : Controller
    {
        private interest_ratesContext _context;

        public ProcentBasesController(interest_ratesContext context)
        {
            _context = context;
        }

        // GET: ProcentBases
        public async Task<IActionResult> Index()
        {
              return _context.ProcentBase != null ? 
                          View(await _context.ProcentBase.ToListAsync()) :
                          Problem("Entity set 'DESKTOP-BH33E8D'  is null.");
        }

        // GET: ProcentBases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProcentBase == null)
            {
                return NotFound();
            }

            var procentBase = await _context.ProcentBase
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procentBase == null)
            {
                return NotFound();
            }

            return View(procentBase);
        }

        // GET: ProcentBases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProcentBases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,bank_name,program_name,procent")] ProcentBase procentBase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procentBase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procentBase);
        }

        // GET: ProcentBases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProcentBase == null)
            {
                return NotFound();
            }

            var procentBase = await _context.ProcentBase.FindAsync(id);
            if (procentBase == null)
            {
                return NotFound();
            }
            return View(procentBase);
        }

        // POST: ProcentBases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,bank_name,program_name,procent")] ProcentBase procentBase)
        {
            if (id != procentBase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procentBase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcentBaseExists(procentBase.Id))
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
            return View(procentBase);
        }

        // GET: ProcentBases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProcentBase == null)
            {
                return NotFound();
            }

            var procentBase = await _context.ProcentBase
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procentBase == null)
            {
                return NotFound();
            }

            return View(procentBase);
        }

        // POST: ProcentBases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProcentBase == null)
            {
                return Problem("Entity set 'DESKTOP-BH33E8D' is null.");
            }
            var procentBase = await _context.ProcentBase.FindAsync(id);
            if (procentBase != null)
            {
                _context.ProcentBase.Remove(procentBase);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcentBaseExists(int id)
        {
          return (_context.ProcentBase?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
