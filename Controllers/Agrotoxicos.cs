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
    public class Agrotoxicos : Controller
    {
        private readonly SerranaContext _context;

        public Agrotoxicos(SerranaContext context)
        {
            _context = context;
        }

        // GET: Agrotoxicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agrotoxico.ToListAsync());
        }

        // GET: Agrotoxicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agrotoxico = await _context.Agrotoxico
                .FirstOrDefaultAsync(m => m.Agro_Id == id);
            if (agrotoxico == null)
            {
                return NotFound();
            }

            return View(agrotoxico);
        }

        // GET: Agrotoxicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agrotoxicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Agro_Id,Nome,Qtd_Disponivel,Unidade_Medida")] Agrotoxico agrotoxico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agrotoxico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agrotoxico);
        }

        // GET: Agrotoxicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agrotoxico = await _context.Agrotoxico.FindAsync(id);
            if (agrotoxico == null)
            {
                return NotFound();
            }
            return View(agrotoxico);
        }

        // POST: Agrotoxicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Agro_Id,Nome,Qtd_Disponivel,Unidade_Medida")] Agrotoxico agrotoxico)
        {
            if (id != agrotoxico.Agro_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agrotoxico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgrotoxicoExists(agrotoxico.Agro_Id))
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
            return View(agrotoxico);
        }

        // GET: Agrotoxicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agrotoxico = await _context.Agrotoxico
                .FirstOrDefaultAsync(m => m.Agro_Id == id);
            if (agrotoxico == null)
            {
                return NotFound();
            }

            return View(agrotoxico);
        }

        // POST: Agrotoxicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agrotoxico = await _context.Agrotoxico.FindAsync(id);
            _context.Agrotoxico.Remove(agrotoxico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgrotoxicoExists(int id)
        {
            return _context.Agrotoxico.Any(e => e.Agro_Id == id);
        }
    }
}
