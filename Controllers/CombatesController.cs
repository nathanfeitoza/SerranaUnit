using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Serrana.Models;
using Serrana.Models.Context;

namespace Serrana.Controllers
{
    public class CombatesController : Controller
    {
        private readonly SerranaContext _context;

        public CombatesController(SerranaContext context)
        {
            _context = context;
        }

        // GET: Combates
        public async Task<IActionResult> Index()
        {
            var serranaContext = _context.Combate.Include(c => c.Agrotoxico).Include(c => c.Praga);
            return View(await serranaContext.ToListAsync());
        }

        // GET: Combates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var combate = await _context.Combate
                .Include(c => c.Agrotoxico)
                .Include(c => c.Praga)
                .FirstOrDefaultAsync(m => m.Agro_Id == id);
            if (combate == null)
            {
                return NotFound();
            }

            return View(combate);
        }

        // GET: Combates/Create
        public IActionResult Create()
        {
            ViewData["Agro_Id"] = new SelectList(_context.Agrotoxico, "Agro_Id", "Nome");
            ViewData["Praga_Id"] = new SelectList(_context.Praga, "Praga_Id", "Estacao");
            return View();
        }

        // POST: Combates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Praga_Id,Agro_Id")] Combate combate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(combate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Agro_Id"] = new SelectList(_context.Agrotoxico, "Agro_Id", "Nome", combate.Agro_Id);
            ViewData["Praga_Id"] = new SelectList(_context.Praga, "Praga_Id", "Estacao", combate.Praga_Id);
            return View(combate);
        }

        // GET: Combates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var combate = await _context.Combate.FindAsync(id);
            if (combate == null)
            {
                return NotFound();
            }
            ViewData["Agro_Id"] = new SelectList(_context.Agrotoxico, "Agro_Id", "Nome", combate.Agro_Id);
            ViewData["Praga_Id"] = new SelectList(_context.Praga, "Praga_Id", "Estacao", combate.Praga_Id);
            return View(combate);
        }

        // POST: Combates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Praga_Id,Agro_Id")] Combate combate)
        {
            if (id != combate.Agro_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(combate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CombateExists(combate.Agro_Id))
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
            ViewData["Agro_Id"] = new SelectList(_context.Agrotoxico, "Agro_Id", "Nome", combate.Agro_Id);
            ViewData["Praga_Id"] = new SelectList(_context.Praga, "Praga_Id", "Estacao", combate.Praga_Id);
            return View(combate);
        }

        // GET: Combates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var combate = await _context.Combate
                .Include(c => c.Agrotoxico)
                .Include(c => c.Praga)
                .FirstOrDefaultAsync(m => m.Agro_Id == id);
            if (combate == null)
            {
                return NotFound();
            }

            return View(combate);
        }

        // POST: Combates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var combate = await _context.Combate.FindAsync(id);
            _context.Combate.Remove(combate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CombateExists(int id)
        {
            return _context.Combate.Any(e => e.Agro_Id == id);
        }
    }
}
