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
    public class ClassificacaoHotelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassificacaoHotelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClassificacaoHotels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassificacaoHotel.ToListAsync());
        }

        // GET: ClassificacaoHotels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificacaoHotel = await _context.ClassificacaoHotel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classificacaoHotel == null)
            {
                return NotFound();
            }

            return View(classificacaoHotel);
        }

        // GET: ClassificacaoHotels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassificacaoHotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeClassificacaoHotel")] ClassificacaoHotel classificacaoHotel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classificacaoHotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classificacaoHotel);
        }

        // GET: ClassificacaoHotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificacaoHotel = await _context.ClassificacaoHotel.FindAsync(id);
            if (classificacaoHotel == null)
            {
                return NotFound();
            }
            return View(classificacaoHotel);
        }

        // POST: ClassificacaoHotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeClassificacaoHotel")] ClassificacaoHotel classificacaoHotel)
        {
            if (id != classificacaoHotel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classificacaoHotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassificacaoHotelExists(classificacaoHotel.Id))
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
            return View(classificacaoHotel);
        }

        // GET: ClassificacaoHotels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificacaoHotel = await _context.ClassificacaoHotel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classificacaoHotel == null)
            {
                return NotFound();
            }

            return View(classificacaoHotel);
        }

        // POST: ClassificacaoHotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classificacaoHotel = await _context.ClassificacaoHotel.FindAsync(id);
            _context.ClassificacaoHotel.Remove(classificacaoHotel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassificacaoHotelExists(int id)
        {
            return _context.ClassificacaoHotel.Any(e => e.Id == id);
        }
    }
}
