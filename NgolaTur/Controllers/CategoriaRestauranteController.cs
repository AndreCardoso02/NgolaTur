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
    public class CategoriaRestauranteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaRestauranteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaRestaurantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaRestaurante.ToListAsync());
        }

        // GET: CategoriaRestaurantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaRestaurante = await _context.CategoriaRestaurante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaRestaurante == null)
            {
                return NotFound();
            }

            return View(categoriaRestaurante);
        }

        // GET: CategoriaRestaurantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaRestaurantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoCategoria")] CategoriaRestaurante categoriaRestaurante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaRestaurante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaRestaurante);
        }

        // GET: CategoriaRestaurantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaRestaurante = await _context.CategoriaRestaurante.FindAsync(id);
            if (categoriaRestaurante == null)
            {
                return NotFound();
            }
            return View(categoriaRestaurante);
        }

        // POST: CategoriaRestaurantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoCategoria")] CategoriaRestaurante categoriaRestaurante)
        {
            if (id != categoriaRestaurante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaRestaurante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaRestauranteExists(categoriaRestaurante.Id))
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
            return View(categoriaRestaurante);
        }

        // GET: CategoriaRestaurantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaRestaurante = await _context.CategoriaRestaurante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaRestaurante == null)
            {
                return NotFound();
            }

            return View(categoriaRestaurante);
        }

        // POST: CategoriaRestaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaRestaurante = await _context.CategoriaRestaurante.FindAsync(id);
            _context.CategoriaRestaurante.Remove(categoriaRestaurante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaRestauranteExists(int id)
        {
            return _context.CategoriaRestaurante.Any(e => e.Id == id);
        }
    }
}
