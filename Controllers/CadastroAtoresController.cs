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
    public class CadastroAtoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CadastroAtoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CadastroAtores
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroAtor.ToListAsync());
        }

        // GET: CadastroAtores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroAtor = await _context.CadastroAtor
                .Include(p => p.VinculoFilmeAtor)
                .ThenInclude(g => g.RegistrarFilme)
                .Include(f => f.VinculoAtorPersonagem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroAtor == null)
            {
                return NotFound();
            }

            return View(cadastroAtor);
        }

        // GET: CadastroAtores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroAtores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DtNascimento,PaisNascimento,FotoArtista")] CadastroAtor cadastroAtor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroAtor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroAtor);
        }

        // GET: CadastroAtores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroAtor = await _context.CadastroAtor.FindAsync(id);
            if (cadastroAtor == null)
            {
                return NotFound();
            }
            return View(cadastroAtor);
        }

        // POST: CadastroAtores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DtNascimento,PaisNascimento,FotoArtista")] CadastroAtor cadastroAtor)
        {
            if (id != cadastroAtor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroAtor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroAtorExists(cadastroAtor.Id))
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
            return View(cadastroAtor);
        }

        // GET: CadastroAtores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroAtor = await _context.CadastroAtor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroAtor == null)
            {
                return NotFound();
            }

            return View(cadastroAtor);
        }

        // POST: CadastroAtores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroAtor = await _context.CadastroAtor.FindAsync(id);
            if (cadastroAtor != null)
            {
                _context.CadastroAtor.Remove(cadastroAtor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroAtorExists(int id)
        {
            return _context.CadastroAtor.Any(e => e.Id == id);
        }
    }
}
