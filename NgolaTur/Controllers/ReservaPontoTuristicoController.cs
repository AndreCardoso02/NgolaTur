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
    public class ReservaPontoTuristicoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservaPontoTuristicoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReservaPontoTuristicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReservaPontoTuristico.ToListAsync());
        }

        // GET: ReservaPontoTuristicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaPontoTuristico = await _context.ReservaPontoTuristico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservaPontoTuristico == null)
            {
                return NotFound();
            }

            return View(reservaPontoTuristico);
        }

        // GET: ReservaPontoTuristicoes/Create
        public IActionResult Create()
        {
            ViewBag.IdPontoTuristico = DropdownHelper.GetPontoTuristicoList(_context);
            ViewBag.IdUsuario = DropdownHelper.GetUsuarioList(_context);

            return View();
        }

        // POST: ReservaPontoTuristicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataEntrada,DataSaida,IdPontoTuristico,IdUsuario")] ReservaPontoTuristico reservaPontoTuristico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaPontoTuristico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.IdPontoTuristico = DropdownHelper.GetPontoTuristicoList(_context);
            ViewBag.IdUsuario = DropdownHelper.GetUsuarioList(_context);

            return View(reservaPontoTuristico);
        }

        // GET: ReservaPontoTuristicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaPontoTuristico = await _context.ReservaPontoTuristico.FindAsync(id);
            if (reservaPontoTuristico == null)
            {
                return NotFound();
            }
            ViewBag.IdPontoTuristico = DropdownHelper.GetPontoTuristicoList(_context);
            ViewBag.IdUsuario = DropdownHelper.GetUsuarioList(_context);

            return View(reservaPontoTuristico);
        }

        // POST: ReservaPontoTuristicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataEntrada,DataSaida,IdPontoTuristico,IdUsuario")] ReservaPontoTuristico reservaPontoTuristico)
        {
            if (id != reservaPontoTuristico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaPontoTuristico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaPontoTuristicoExists(reservaPontoTuristico.Id))
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
            ViewBag.IdPontoTuristico = DropdownHelper.GetPontoTuristicoList(_context);
            ViewBag.IdUsuario = DropdownHelper.GetUsuarioList(_context);

            return View(reservaPontoTuristico);
        }

        // GET: ReservaPontoTuristicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaPontoTuristico = await _context.ReservaPontoTuristico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservaPontoTuristico == null)
            {
                return NotFound();
            }

            return View(reservaPontoTuristico);
        }

        // POST: ReservaPontoTuristicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaPontoTuristico = await _context.ReservaPontoTuristico.FindAsync(id);
            _context.ReservaPontoTuristico.Remove(reservaPontoTuristico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaPontoTuristicoExists(int id)
        {
            return _context.ReservaPontoTuristico.Any(e => e.Id == id);
        }
    }
}
