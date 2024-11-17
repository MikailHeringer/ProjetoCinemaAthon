using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoCinemaAthon.Data;
using ProjetoCinemaAthon.Models;

namespace ProjetoCinemaAthon.Controllers
{
    public class BuscasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BuscasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Buscas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Busca.ToListAsync());
        }

        // GET: Buscas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busca = await _context.Busca
                .FirstOrDefaultAsync(m => m.Id == id);
            if (busca == null)
            {
                return NotFound();
            }

            return View(busca);
        }

        // GET: Buscas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buscas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Busca busca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(busca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(busca);
        }

        // GET: Buscas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busca = await _context.Busca.FindAsync(id);
            if (busca == null)
            {
                return NotFound();
            }
            return View(busca);
        }

        // POST: Buscas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Busca busca)
        {
            if (id != busca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(busca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuscaExists(busca.Id))
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
            return View(busca);
        }

        // GET: Buscas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busca = await _context.Busca
                .FirstOrDefaultAsync(m => m.Id == id);
            if (busca == null)
            {
                return NotFound();
            }

            return View(busca);
        }

        // POST: Buscas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var busca = await _context.Busca.FindAsync(id);
            if (busca != null)
            {
                _context.Busca.Remove(busca);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuscaExists(int id)
        {
            return _context.Busca.Any(e => e.Id == id);
        }
    }
}
