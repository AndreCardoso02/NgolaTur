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
    public class ReservaRestauranteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservaRestauranteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReservaRestaurantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReservaRestaurante.ToListAsync());
        }

        // GET: ReservaRestaurantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaRestaurante = await _context.ReservaRestaurante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservaRestaurante == null)
            {
                return NotFound();
            }

            return View(reservaRestaurante);
        }

        // GET: ReservaRestaurantes/Create
        public IActionResult Create()
        {
            ViewBag.IdRestaurante = DropdownHelper.GetRestaurantesList(_context);
            ViewBag.IdUsuario = DropdownHelper.GetUsuarioList(_context);

            return View();
        }

        // POST: ReservaRestaurantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataEntrada,DataSaida,IdRestaurante,IdUsuario")] ReservaRestaurante reservaRestaurante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaRestaurante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.IdRestaurante = DropdownHelper.GetRestaurantesList(_context);
            ViewBag.IdUsuario = DropdownHelper.GetUsuarioList(_context);

            return View(reservaRestaurante);
        }

        // GET: ReservaRestaurantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaRestaurante = await _context.ReservaRestaurante.FindAsync(id);
            if (reservaRestaurante == null)
            {
                return NotFound();
            }
            ViewBag.IdRestaurante = DropdownHelper.GetRestaurantesList(_context);
            ViewBag.IdUsuario = DropdownHelper.GetUsuarioList(_context);

            return View(reservaRestaurante);
        }

        // POST: ReservaRestaurantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataEntrada,DataSaida,IdRestaurante,IdUsuario")] ReservaRestaurante reservaRestaurante)
        {
            if (id != reservaRestaurante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaRestaurante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaRestauranteExists(reservaRestaurante.Id))
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
            ViewBag.IdRestaurante = DropdownHelper.GetRestaurantesList(_context);
            ViewBag.IdUsuario = DropdownHelper.GetUsuarioList(_context);

            return View(reservaRestaurante);
        }

        // GET: ReservaRestaurantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaRestaurante = await _context.ReservaRestaurante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservaRestaurante == null)
            {
                return NotFound();
            }

            return View(reservaRestaurante);
        }

        // POST: ReservaRestaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaRestaurante = await _context.ReservaRestaurante.FindAsync(id);
            _context.ReservaRestaurante.Remove(reservaRestaurante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaRestauranteExists(int id)
        {
            return _context.ReservaRestaurante.Any(e => e.Id == id);
        }
    }
}
