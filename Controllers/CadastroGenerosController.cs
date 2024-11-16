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
    public class CadastroGenerosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CadastroGenerosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CadastroGeneros
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroGenero.ToListAsync());
        }

        // GET: CadastroGeneros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroGenero = await _context.CadastroGenero
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroGenero == null)
            {
                return NotFound();
            }

            return View(cadastroGenero);
        }

        // GET: CadastroGeneros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroGeneros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] CadastroGenero cadastroGenero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroGenero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroGenero);
        }

        // GET: CadastroGeneros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroGenero = await _context.CadastroGenero.FindAsync(id);
            if (cadastroGenero == null)
            {
                return NotFound();
            }
            return View(cadastroGenero);
        }

        // POST: CadastroGeneros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] CadastroGenero cadastroGenero)
        {
            if (id != cadastroGenero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroGenero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroGeneroExists(cadastroGenero.Id))
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
            return View(cadastroGenero);
        }

        // GET: CadastroGeneros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroGenero = await _context.CadastroGenero
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroGenero == null)
            {
                return NotFound();
            }

            return View(cadastroGenero);
        }

        // POST: CadastroGeneros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroGenero = await _context.CadastroGenero.FindAsync(id);
            if (cadastroGenero != null)
            {
                _context.CadastroGenero.Remove(cadastroGenero);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroGeneroExists(int id)
        {
            return _context.CadastroGenero.Any(e => e.Id == id);
        }
    }
}
