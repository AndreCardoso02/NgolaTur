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
    public class ReservaQuartoHotelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservaQuartoHotelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReservaQuartoHotels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReservaQuartoHotel.ToListAsync());
        }

        // GET: ReservaQuartoHotels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaQuartoHotel = await _context.ReservaQuartoHotel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservaQuartoHotel == null)
            {
                return NotFound();
            }

            return View(reservaQuartoHotel);
        }

        // GET: ReservaQuartoHotels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReservaQuartoHotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataEntrada,DataSaida,IdTipoQuartoHotel,IdUsuario")] ReservaQuartoHotel reservaQuartoHotel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaQuartoHotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.IdTipoQuartoHotel = DropdownHelper.GetTipoQuartoHotelList(_context);
            ViewBag.IdUsuario = DropdownHelper.GetUsuarioList(_context);

            return View(reservaQuartoHotel);
        }

        // GET: ReservaQuartoHotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaQuartoHotel = await _context.ReservaQuartoHotel.FindAsync(id);
            if (reservaQuartoHotel == null)
            {
                return NotFound();
            }
            ViewBag.IdTipoQuartoHotel = DropdownHelper.GetTipoQuartoHotelList(_context);
            ViewBag.IdUsuario = DropdownHelper.GetUsuarioList(_context);

            return View(reservaQuartoHotel);
        }

        // POST: ReservaQuartoHotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataEntrada,DataSaida,IdTipoQuartoHotel,IdUsuario")] ReservaQuartoHotel reservaQuartoHotel)
        {
            if (id != reservaQuartoHotel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaQuartoHotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaQuartoHotelExists(reservaQuartoHotel.Id))
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
            ViewBag.IdTipoQuartoHotel = DropdownHelper.GetTipoQuartoHotelList(_context);
            ViewBag.IdUsuario = DropdownHelper.GetUsuarioList(_context);

            return View(reservaQuartoHotel);
        }

        // GET: ReservaQuartoHotels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaQuartoHotel = await _context.ReservaQuartoHotel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservaQuartoHotel == null)
            {
                return NotFound();
            }
            ViewBag.IdTipoQuartoHotel = DropdownHelper.GetTipoQuartoHotelList(_context);
            ViewBag.IdUsuario = DropdownHelper.GetUsuarioList(_context);

            return View(reservaQuartoHotel);
        }

        // POST: ReservaQuartoHotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaQuartoHotel = await _context.ReservaQuartoHotel.FindAsync(id);
            _context.ReservaQuartoHotel.Remove(reservaQuartoHotel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaQuartoHotelExists(int id)
        {
            return _context.ReservaQuartoHotel.Any(e => e.Id == id);
        }
    }
}
