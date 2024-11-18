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
    public class PesquisasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PesquisasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pesquisas
        public async Task<IActionResult> Index()
        {
            var filmes = await _context.RegistrarFilme
        .Include(f => f.VinculoFilmeAtor)
            .ThenInclude(v => v.CadastroAtor)
        .Include(f => f.VinculoFilmeGenero)
            .ThenInclude(v => v.CadastroGenero)
        .Select(f => new
        {
            f.Id,
            f.Titulo,
            f.DtLancamento,
            f.LinkCapa,
            Artistas = f.VinculoFilmeAtor
                .Where(v => v.RegistrarFilmeId == f.Id)
                .Select(v => v.CadastroAtor.Nome)
                .Distinct()
                .ToList(),
            Generos = f.VinculoFilmeGenero
                .Where(g => g.RegistrarFilmeId == f.Id)
                .Select(g => g.CadastroGenero.Nome)
                .Distinct()
                .ToList()
        })
        .ToListAsync();

            var artistas = await _context.CadastroAtor
                .Select(a => new
                {
                    a.Id,
                    a.Nome,
                    a.PaisNascimento,
                    a.FotoArtista
                })
                .ToListAsync();

            var model = new
            {
                Filme = filmes,
                Artista = artistas,
            };
            return View(model);
        }

        // GET: Pesquisas/Details/5
       /* public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesquisa = await _context.Pesquisa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pesquisa == null)
            {
                return NotFound();
            }

            return View(pesquisa);
        }

        // GET: Pesquisas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pesquisas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Pesquisa pesquisa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pesquisa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pesquisa);
        }

        // GET: Pesquisas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesquisa = await _context.Pesquisa.FindAsync(id);
            if (pesquisa == null)
            {
                return NotFound();
            }
            return View(pesquisa);
        }

        // POST: Pesquisas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Pesquisa pesquisa)
        {
            if (id != pesquisa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pesquisa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PesquisaExists(pesquisa.Id))
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
            return View(pesquisa);
        }

        // GET: Pesquisas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesquisa = await _context.Pesquisa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pesquisa == null)
            {
                return NotFound();
            }

            return View(pesquisa);
        }

        // POST: Pesquisas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pesquisa = await _context.Pesquisa.FindAsync(id);
            if (pesquisa != null)
            {
                _context.Pesquisa.Remove(pesquisa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PesquisaExists(int id)
        {
            return _context.Pesquisa.Any(e => e.Id == id);
        }*/
    }
}
