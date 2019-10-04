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
    public class AplicacaoAgrotoxicosController : Controller
    {
        private readonly SerranaContext _context;

        public AplicacaoAgrotoxicosController(SerranaContext context)
        {
            _context = context;
        }

        // GET: AplicacaoAgrotoxicos
        public async Task<IActionResult> Index()
        {
            var serranaContext = _context.AplicacaoAgrotoxicos.Include(a => a.Agrotoxico).Include(a => a.Area);
            return View(await serranaContext.ToListAsync());
        }

        // GET: AplicacaoAgrotoxicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicacaoAgrotoxico = await _context.AplicacaoAgrotoxicos
                .Include(a => a.Agrotoxico)
                .Include(a => a.Area)
                .FirstOrDefaultAsync(m => m.Area_Id == id);
            if (aplicacaoAgrotoxico == null)
            {
                return NotFound();
            }

            return View(aplicacaoAgrotoxico);
        }

        // GET: AplicacaoAgrotoxicos/Create
        public IActionResult Create()
        {
            ViewData["Agro_Id"] = new SelectList(_context.Agrotoxico, "Agro_Id", "Nome");
            ViewData["Area_Id"] = new SelectList(_context.Area, "Area_Id", "Area_Id");
            return View();
        }

        // POST: AplicacaoAgrotoxicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Qtd_Aplicada,Tipo,Area_Id,Agro_Id")] AplicacaoAgrotoxico aplicacaoAgrotoxico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aplicacaoAgrotoxico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Agro_Id"] = new SelectList(_context.Agrotoxico, "Agro_Id", "Nome", aplicacaoAgrotoxico.Agro_Id);
            ViewData["Area_Id"] = new SelectList(_context.Area, "Area_Id", "Area_Id", aplicacaoAgrotoxico.Area_Id);
            return View(aplicacaoAgrotoxico);
        }

        // GET: AplicacaoAgrotoxicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicacaoAgrotoxico = await _context.AplicacaoAgrotoxicos.FindAsync(id);
            if (aplicacaoAgrotoxico == null)
            {
                return NotFound();
            }
            ViewData["Agro_Id"] = new SelectList(_context.Agrotoxico, "Agro_Id", "Nome", aplicacaoAgrotoxico.Agro_Id);
            ViewData["Area_Id"] = new SelectList(_context.Area, "Area_Id", "Area_Id", aplicacaoAgrotoxico.Area_Id);
            return View(aplicacaoAgrotoxico);
        }

        // POST: AplicacaoAgrotoxicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Qtd_Aplicada,Tipo,Area_Id,Agro_Id")] AplicacaoAgrotoxico aplicacaoAgrotoxico)
        {
            if (id != aplicacaoAgrotoxico.Area_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aplicacaoAgrotoxico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AplicacaoAgrotoxicoExists(aplicacaoAgrotoxico.Area_Id))
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
            ViewData["Agro_Id"] = new SelectList(_context.Agrotoxico, "Agro_Id", "Nome", aplicacaoAgrotoxico.Agro_Id);
            ViewData["Area_Id"] = new SelectList(_context.Area, "Area_Id", "Area_Id", aplicacaoAgrotoxico.Area_Id);
            return View(aplicacaoAgrotoxico);
        }

        // GET: AplicacaoAgrotoxicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicacaoAgrotoxico = await _context.AplicacaoAgrotoxicos
                .Include(a => a.Agrotoxico)
                .Include(a => a.Area)
                .FirstOrDefaultAsync(m => m.Area_Id == id);
            if (aplicacaoAgrotoxico == null)
            {
                return NotFound();
            }

            return View(aplicacaoAgrotoxico);
        }

        // POST: AplicacaoAgrotoxicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aplicacaoAgrotoxico = await _context.AplicacaoAgrotoxicos.FindAsync(id);
            _context.AplicacaoAgrotoxicos.Remove(aplicacaoAgrotoxico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AplicacaoAgrotoxicoExists(int id)
        {
            return _context.AplicacaoAgrotoxicos.Any(e => e.Area_Id == id);
        }
    }
}
