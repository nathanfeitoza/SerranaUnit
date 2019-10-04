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
    public class AreasController : Controller
    {
        private readonly SerranaContext _context;

        public AreasController(SerranaContext context)
        {
            _context = context;
        }

        // GET: Areas
        public async Task<IActionResult> Index()
        {
            var serranaContext = _context.Area.Include(a => a.Cultura).Include(a => a.Funcionario);
            return View(await serranaContext.ToListAsync());
        }

        // GET: Areas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.Area
                .Include(a => a.Cultura)
                .Include(a => a.Funcionario)
                .Include(a => a.AplicacoesAgrotoxicos)
                .FirstOrDefaultAsync(m => m.Area_Id == id);
            if (area == null)
            {
                return NotFound();
            }

            return View(area);
        }

        // GET: Areas/Create
        public IActionResult Create()
        {
            ViewData["Cultura_Id"] = new SelectList(_context.Cultura, "Cultura_Id", "Nome");
            ViewData["Maticula_Funcionario"] = new SelectList(_context.Funcionario, "Matricula", "Cargo");
            return View();
        }

        // POST: Areas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Area_Id,Tamanho,Status,Cultura_Id,Maticula_Funcionario")] Area area)
        {
            if (ModelState.IsValid)
            {
                _context.Add(area);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cultura_Id"] = new SelectList(_context.Cultura, "Cultura_Id", "Nome", area.Cultura_Id);
            ViewData["Maticula_Funcionario"] = new SelectList(_context.Funcionario, "Matricula", "Matricula", area.Maticula_Funcionario);
            return View(area);
        }

        // GET: Areas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.Area.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }
            ViewData["Cultura_Id"] = new SelectList(_context.Cultura, "Cultura_Id", "Nome", area.Cultura_Id);
            ViewData["Maticula_Funcionario"] = new SelectList(_context.Funcionario, "Matricula", "Cargo", area.Maticula_Funcionario);
            return View(area);
        }

        // POST: Areas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Area_Id,Tamanho,Status,Cultura_Id,Maticula_Funcionario")] Area area)
        {
            if (id != area.Area_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(area);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaExists(area.Area_Id))
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
            ViewData["Cultura_Id"] = new SelectList(_context.Cultura, "Cultura_Id", "Nome", area.Cultura_Id);
            ViewData["Maticula_Funcionario"] = new SelectList(_context.Funcionario, "Matricula", "Cargo", area.Maticula_Funcionario);
            return View(area);
        }

        // GET: Areas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.Area
                .Include(a => a.Cultura)
                .Include(a => a.Funcionario)
                .FirstOrDefaultAsync(m => m.Area_Id == id);
            if (area == null)
            {
                return NotFound();
            }

            return View(area);
        }

        // POST: Areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var area = await _context.Area.FindAsync(id);
            _context.Area.Remove(area);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaExists(int id)
        {
            return _context.Area.Any(e => e.Area_Id == id);
        }
    }
}
