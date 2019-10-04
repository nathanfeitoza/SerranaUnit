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
    public class CulturasController : Controller
    {
        private readonly SerranaContext _context;

        public CulturasController(SerranaContext context)
        {
            _context = context;
        }

        // GET: Culturas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cultura.ToListAsync());
        }

        // GET: Culturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cultura = await _context.Cultura
                .FirstOrDefaultAsync(m => m.Cultura_Id == id);
            if (cultura == null)
            {
                return NotFound();
            }

            return View(cultura);
        }

        // GET: Culturas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Culturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cultura_Id,Nome,Mes_Inicio,Mes_Fim,Data_Inicio,TempoMaximo")] Cultura cultura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cultura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cultura);
        }

        // GET: Culturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cultura = await _context.Cultura.FindAsync(id);
            if (cultura == null)
            {
                return NotFound();
            }
            return View(cultura);
        }

        // POST: Culturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cultura_Id,Nome,Mes_Inicio,Mes_Fim,Data_Inicio,TempoMaximo")] Cultura cultura)
        {
            if (id != cultura.Cultura_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cultura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CulturaExists(cultura.Cultura_Id))
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
            return View(cultura);
        }

        // GET: Culturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cultura = await _context.Cultura
                .FirstOrDefaultAsync(m => m.Cultura_Id == id);
            if (cultura == null)
            {
                return NotFound();
            }

            return View(cultura);
        }

        // POST: Culturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cultura = await _context.Cultura.FindAsync(id);
            _context.Cultura.Remove(cultura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CulturaExists(int id)
        {
            return _context.Cultura.Any(e => e.Cultura_Id == id);
        }
    }
}
