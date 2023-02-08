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
    public class TipoQuartoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoQuartoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoQuartoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoQuarto.ToListAsync());
        }

        // GET: TipoQuartoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoQuarto = await _context.TipoQuarto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoQuarto == null)
            {
                return NotFound();
            }

            return View(tipoQuarto);
        }

        // GET: TipoQuartoes/Create
        public IActionResult Create()
        {
            ViewBag.IdHotel = DropdownHelper.GetHotelList(_context);

            return View();
        }

        // POST: TipoQuartoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeTipoQuarto,Preco,IdHotel")] TipoQuarto tipoQuarto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoQuarto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.IdHotel = DropdownHelper.GetHotelList(_context);

            return View(tipoQuarto);
        }

        // GET: TipoQuartoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoQuarto = await _context.TipoQuarto.FindAsync(id);
            if (tipoQuarto == null)
            {
                return NotFound();
            }
            ViewBag.IdHotel = DropdownHelper.GetHotelList(_context);

            return View(tipoQuarto);
        }

        // POST: TipoQuartoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeTipoQuarto,Preco,IdHotel")] TipoQuarto tipoQuarto)
        {
            if (id != tipoQuarto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoQuarto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoQuartoExists(tipoQuarto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.IdHotel = DropdownHelper.GetHotelList(_context);

                return RedirectToAction(nameof(Index));
            }
            return View(tipoQuarto);
        }

        // GET: TipoQuartoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoQuarto = await _context.TipoQuarto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoQuarto == null)
            {
                return NotFound();
            }

            return View(tipoQuarto);
        }

        // POST: TipoQuartoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoQuarto = await _context.TipoQuarto.FindAsync(id);
            _context.TipoQuarto.Remove(tipoQuarto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoQuartoExists(int id)
        {
            return _context.TipoQuarto.Any(e => e.Id == id);
        }
    }
}
