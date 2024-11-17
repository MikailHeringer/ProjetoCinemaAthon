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
    public class BuscaArtistasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BuscaArtistasController(ApplicationDbContext context)
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

            return RedirectToAction("Index", "BuscarArtista");
        }
    }
}
