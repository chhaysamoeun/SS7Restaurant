using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SS7Restaurant.Data;
using SS7Restaurant.Models;

namespace SS7Restaurant.Controllers
{
    public class TablesController : Controller
    {
        private readonly AppDbContext _context;

        public TablesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Tables
        public async Task<IActionResult> Index()
        {
              return View(await _context.Tables.ToListAsync());
        }

        // GET: Tables/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Tables == null)
            {
                return NotFound();
            }

            var tables = await _context.Tables
                .FirstOrDefaultAsync(m => m.TableId == id);
            if (tables == null)
            {
                return NotFound();
            }

            return View(tables);
        }

        // GET: Tables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TableId,TableNumber,Description")] Tables tables)
        {
            if (ModelState.IsValid)
            {
                tables.TableId = Guid.NewGuid();
                _context.Add(tables);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tables);
        }

        // GET: Tables/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Tables == null)
            {
                return NotFound();
            }

            var tables = await _context.Tables.FindAsync(id);
            if (tables == null)
            {
                return NotFound();
            }
            return View(tables);
        }

        // POST: Tables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TableId,TableNumber,Description")] Tables tables)
        {
            if (id != tables.TableId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tables);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablesExists(tables.TableId))
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
            return View(tables);
        }

        // GET: Tables/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Tables == null)
            {
                return NotFound();
            }

            var tables = await _context.Tables
                .FirstOrDefaultAsync(m => m.TableId == id);
            if (tables == null)
            {
                return NotFound();
            }

            return View(tables);
        }

        // POST: Tables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Tables == null)
            {
                return Problem("Entity set 'AppDbContext.Tables'  is null.");
            }
            var tables = await _context.Tables.FindAsync(id);
            if (tables != null)
            {
                _context.Tables.Remove(tables);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablesExists(Guid id)
        {
          return _context.Tables.Any(e => e.TableId == id);
        }
    }
}
