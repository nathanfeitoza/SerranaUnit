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
    public class AtaquesController : Controller
    {
        private readonly SerranaContext _context;

        public AtaquesController(SerranaContext context)
        {
            _context = context;
        }

        // GET: Ataques
        public async Task<IActionResult> Index()
        {
            var serranaContext = _context.Ataque.Include(a => a.Cultura).Include(a => a.Praga);
            return View(await serranaContext.ToListAsync());
        }

        // GET: Ataques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ataque = await _context.Ataque
                .Include(a => a.Cultura)
                .Include(a => a.Praga)
                .FirstOrDefaultAsync(m => m.Cultura_Id == id);
            if (ataque == null)
            {
                return NotFound();
            }

            return View(ataque);
        }

        // GET: Ataques/Create
        public IActionResult Create()
        {
            ViewData["Cultura_Id"] = new SelectList(_context.Cultura, "Cultura_Id", "Nome");
            ViewData["Praga_Id"] = new SelectList(_context.Praga, "Praga_Id", "Estacao");
            return View();
        }

        // POST: Ataques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cultura_Id,Praga_Id")] Ataque ataque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ataque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cultura_Id"] = new SelectList(_context.Cultura, "Cultura_Id", "Nome", ataque.Cultura_Id);
            ViewData["Praga_Id"] = new SelectList(_context.Praga, "Praga_Id", "Estacao", ataque.Praga_Id);
            return View(ataque);
        }

        // GET: Ataques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ataque = await _context.Ataque.FindAsync(id);
            if (ataque == null)
            {
                return NotFound();
            }
            ViewData["Cultura_Id"] = new SelectList(_context.Cultura, "Cultura_Id", "Nome", ataque.Cultura_Id);
            ViewData["Praga_Id"] = new SelectList(_context.Praga, "Praga_Id", "Estacao", ataque.Praga_Id);
            return View(ataque);
        }

        // POST: Ataques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cultura_Id,Praga_Id")] Ataque ataque)
        {
            if (id != ataque.Cultura_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ataque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtaqueExists(ataque.Cultura_Id))
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
            ViewData["Cultura_Id"] = new SelectList(_context.Cultura, "Cultura_Id", "Nome", ataque.Cultura_Id);
            ViewData["Praga_Id"] = new SelectList(_context.Praga, "Praga_Id", "Estacao", ataque.Praga_Id);
            return View(ataque);
        }

        // GET: Ataques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ataque = await _context.Ataque
                .Include(a => a.Cultura)
                .Include(a => a.Praga)
                .FirstOrDefaultAsync(m => m.Cultura_Id == id);
            if (ataque == null)
            {
                return NotFound();
            }

            return View(ataque);
        }

        // POST: Ataques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ataque = await _context.Ataque.FindAsync(id);
            _context.Ataque.Remove(ataque);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtaqueExists(int id)
        {
            return _context.Ataque.Any(e => e.Cultura_Id == id);
        }
    }
}
