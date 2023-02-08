using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NgolaTur.Data;
using NgolaTur.Models;

namespace NgolaTur.Controllers
{
    public class TipoPontoTuristicoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoPontoTuristicoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoPontoTuristicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoPontoTuristico.ToListAsync());
        }

        // GET: TipoPontoTuristicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPontoTuristico = await _context.TipoPontoTuristico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoPontoTuristico == null)
            {
                return NotFound();
            }

            return View(tipoPontoTuristico);
        }

        // GET: TipoPontoTuristicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPontoTuristicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeTipoPontoTuristico,Estado")] TipoPontoTuristico tipoPontoTuristico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPontoTuristico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPontoTuristico);
        }

        // GET: TipoPontoTuristicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPontoTuristico = await _context.TipoPontoTuristico.FindAsync(id);
            if (tipoPontoTuristico == null)
            {
                return NotFound();
            }
            return View(tipoPontoTuristico);
        }

        // POST: TipoPontoTuristicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeTipoPontoTuristico,Estado")] TipoPontoTuristico tipoPontoTuristico)
        {
            if (id != tipoPontoTuristico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPontoTuristico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPontoTuristicoExists(tipoPontoTuristico.Id))
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
            return View(tipoPontoTuristico);
        }

        // GET: TipoPontoTuristicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPontoTuristico = await _context.TipoPontoTuristico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoPontoTuristico == null)
            {
                return NotFound();
            }

            return View(tipoPontoTuristico);
        }

        // POST: TipoPontoTuristicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoPontoTuristico = await _context.TipoPontoTuristico.FindAsync(id);
            _context.TipoPontoTuristico.Remove(tipoPontoTuristico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPontoTuristicoExists(int id)
        {
            return _context.TipoPontoTuristico.Any(e => e.Id == id);
        }
    }
}
