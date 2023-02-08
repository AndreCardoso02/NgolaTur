using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NgolaTur.Data;
using NgolaTur.Helpers;
using NgolaTur.Models;

namespace NgolaTur.Controllers
{
    public class PontoTuristicoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PontoTuristicoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PontoTuristicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PontoTuristico.ToListAsync());
        }

        // GET: PontoTuristicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoTuristico = await _context.PontoTuristico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pontoTuristico == null)
            {
                return NotFound();
            }

            return View(pontoTuristico);
        }

        // GET: PontoTuristicoes/Create
        public IActionResult Create()
        {
            ViewBag.IdCidade = DropdownHelper.GetCidadesList(_context);
            ViewBag.IdTipoPontoTuristico = DropdownHelper.GetTipoPontoTuristicoList(_context);

            return View();
        }

        // POST: PontoTuristicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomePontoTuristico,IdCidade,IdTipoPontoTuristico")] PontoTuristico pontoTuristico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pontoTuristico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.IdCidade = DropdownHelper.GetCidadesList(_context);
            ViewBag.IdTipoPontoTuristico = DropdownHelper.GetTipoPontoTuristicoList(_context);

            return View(pontoTuristico);
        }

        // GET: PontoTuristicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoTuristico = await _context.PontoTuristico.FindAsync(id);
            if (pontoTuristico == null)
            {
                return NotFound();
            }
            ViewBag.IdCidade = DropdownHelper.GetCidadesList(_context);
            ViewBag.IdTipoPontoTuristico = DropdownHelper.GetTipoPontoTuristicoList(_context);

            return View(pontoTuristico);
        }

        // POST: PontoTuristicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomePontoTuristico,IdCidade,IdTipoPontoTuristico")] PontoTuristico pontoTuristico)
        {
            if (id != pontoTuristico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pontoTuristico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PontoTuristicoExists(pontoTuristico.Id))
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
            ViewBag.IdCidade = DropdownHelper.GetCidadesList(_context);
            ViewBag.IdTipoPontoTuristico = DropdownHelper.GetTipoPontoTuristicoList(_context);

            return View(pontoTuristico);
        }

        // GET: PontoTuristicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoTuristico = await _context.PontoTuristico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pontoTuristico == null)
            {
                return NotFound();
            }

            return View(pontoTuristico);
        }

        // POST: PontoTuristicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pontoTuristico = await _context.PontoTuristico.FindAsync(id);
            _context.PontoTuristico.Remove(pontoTuristico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PontoTuristicoExists(int id)
        {
            return _context.PontoTuristico.Any(e => e.Id == id);
        }
    }
}
