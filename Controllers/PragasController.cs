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
    public class PragasController : Controller
    {
        private readonly SerranaContext _context;

        public PragasController(SerranaContext context)
        {
            _context = context;
        }

        // GET: Pragas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Praga.ToListAsync());
        }

        // GET: Pragas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var praga = await _context.Praga
                .FirstOrDefaultAsync(m => m.Praga_Id == id);
            if (praga == null)
            {
                return NotFound();
            }

            return View(praga);
        }

        // GET: Pragas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pragas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Praga_Id,Nome_Popular,Nome_Cientifico,Estacao")] Praga praga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(praga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(praga);
        }

        // GET: Pragas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var praga = await _context.Praga.FindAsync(id);
            if (praga == null)
            {
                return NotFound();
            }
            return View(praga);
        }

        // POST: Pragas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Praga_Id,Nome_Popular,Nome_Cientifico,Estacao")] Praga praga)
        {
            if (id != praga.Praga_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(praga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PragaExists(praga.Praga_Id))
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
            return View(praga);
        }

        // GET: Pragas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var praga = await _context.Praga
                .FirstOrDefaultAsync(m => m.Praga_Id == id);
            if (praga == null)
            {
                return NotFound();
            }

            return View(praga);
        }

        // POST: Pragas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var praga = await _context.Praga.FindAsync(id);
            _context.Praga.Remove(praga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PragaExists(int id)
        {
            return _context.Praga.Any(e => e.Praga_Id == id);
        }
    }
}
