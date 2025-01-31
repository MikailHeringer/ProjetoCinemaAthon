﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoCinemaAthon.Data;
using ProjetoCinemaAthon.Models;

namespace ProjetoCinemaAthon.Controllers
{
    public class RegistrarFilmesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistrarFilmesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegistrarFilmes
        public async Task<IActionResult> Index()
        {
            if (TempData["ResId"] != null)
            {
                int resId = (int)TempData["ResId"];
                if (resId == 2)
                {
                    ViewBag.Message = "false";
                }

            }
            return View(await _context.RegistrarFilme.ToListAsync());
        }

        // GET: RegistrarFilmes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrarFilme = await _context.RegistrarFilme
                .Include(p => p.VinculoAtorPersonagem)
                .ThenInclude(g => g.CadastroAtor)
                .Include(f => f.VinculoFilmeGenero)
                .ThenInclude(g => g.CadastroGenero)
                .FirstOrDefaultAsync(m => m.Id == id);




            if (registrarFilme == null)
            {
                return NotFound();
            }

            return View(registrarFilme);
        }

        // GET: RegistrarFilmes/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["DadosGeneros"] = new SelectList(_context.CadastroGenero, "Id", "Nome");
            ViewData["DadosAtor"] = new SelectList(_context.CadastroAtor, "Id", "Nome");
            return View();
        }

        // POST: RegistrarFilmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegistrarFilme registrarFilme, int[] cadastroGeneros, int[] cadastroAtor, string[] CadastroPersonagem)
        {
           if (ModelState.IsValid)
            {

                bool duplicado = await _context.RegistrarFilme
                    .AnyAsync(g => g.Titulo.ToLower() == registrarFilme.Titulo.ToLower());
                if (duplicado)
                {
                    TempData["ResId"] = 2;
                    return RedirectToAction(nameof(Index));
                }

                _context.Add(registrarFilme);
                await _context.SaveChangesAsync();

                for(int i=0; i < cadastroGeneros.Length; i++)
                {
                    VinculoFilmeGenero vinculoFilmeGenero = new();
                    vinculoFilmeGenero.RegistrarFilmeId = registrarFilme.Id;
                    vinculoFilmeGenero.CadastroGeneroId = cadastroGeneros[i];
                    _context.Add(vinculoFilmeGenero);
                }

                for (int i=0; i < cadastroAtor.Length; i++)
                {
                    VinculoFilmeAtor vinculoFilmeAtor = new();
                    vinculoFilmeAtor.RegistrarFilmeId = registrarFilme.Id;
                    vinculoFilmeAtor.CadastroAtorId = cadastroAtor[i];
                    _context.Add(vinculoFilmeAtor);

                    VinculoAtorPersonagem vinculoAtorPersonagem = new();
                    vinculoAtorPersonagem.RegistrarFilmeId = registrarFilme.Id;
                    vinculoAtorPersonagem.CadastroAtorId = cadastroAtor[i];
                    if(CadastroPersonagem[i] == null)
                    {
                        vinculoAtorPersonagem.NomePersonagem = "Não cadastrado";
                    }
                    else
                    {
                        vinculoAtorPersonagem.NomePersonagem = CadastroPersonagem[i];
                    }
                    _context.Add(vinculoAtorPersonagem);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


            /*return View(registrarFilme);*/
        }

        // GET: RegistrarFilmes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrarFilme = await _context.RegistrarFilme
                .Include(p => p.VinculoAtorPersonagem)
                .ThenInclude(g => g.CadastroAtor)
                .Include(f => f.VinculoFilmeGenero)
                .ThenInclude(g => g.CadastroGenero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registrarFilme == null)
            {
                return NotFound();
            }

            ViewData["DadosGeneros"] = new SelectList(_context.CadastroGenero, "Id", "Nome", registrarFilme?.VinculoFilmeGenero?.Select(v => v.CadastroGeneroId));
            ViewData["DadosAtor"] = new SelectList(_context.CadastroAtor, "Id", "Nome", registrarFilme?.VinculoAtorPersonagem?.Select(v => v.CadastroAtorId));

            return View(registrarFilme);
        }

        // POST: RegistrarFilmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RegistrarFilme registrarFilme, int[] cadastroGeneros, int[] cadastroAtor, string[] cadastroPersonagem)
        {
            if (id != registrarFilme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registrarFilme);
                    await _context.SaveChangesAsync();


                    var vinculosAtor = _context.VinculoFilmeAtor.Where(v => v.RegistrarFilmeId == registrarFilme.Id).ToList();
                    foreach (var vinculo in vinculosAtor)
                    {
                        _context.VinculoFilmeAtor.Remove(vinculo);
                    }

                    var vinculosGeneros = _context.VinculoFilmeGenero.Where(v => v.RegistrarFilmeId == registrarFilme.Id).ToList();

                    foreach (var vinculo in vinculosGeneros)
                    {
                        _context.VinculoFilmeGenero.Remove(vinculo);
                    }

                    var vinculosAtores = _context.VinculoAtorPersonagem.Where(v => v.RegistrarFilmeId == registrarFilme.Id).ToList();
                    foreach (var vinculo in vinculosAtores)
                    {
                        _context.VinculoAtorPersonagem.Remove(vinculo);
                    }

                    for (int i = 0; i < cadastroGeneros.Length; i++)
                    {
                        VinculoFilmeGenero vinculoFilmeGenero = new();
                        vinculoFilmeGenero.RegistrarFilmeId = registrarFilme.Id;
                        vinculoFilmeGenero.CadastroGeneroId = cadastroGeneros[i];
                        _context.Add(vinculoFilmeGenero);
                    }

                    for (int i = 0; i < cadastroAtor.Length; i++)
                    {
                        VinculoFilmeAtor vinculoFilmeAtor = new();
                        vinculoFilmeAtor.RegistrarFilmeId = registrarFilme.Id;
                        vinculoFilmeAtor.CadastroAtorId = cadastroAtor[i];
                        _context.Add(vinculoFilmeAtor);

                        VinculoAtorPersonagem vinculoAtorPersonagem = new();
                        vinculoAtorPersonagem.RegistrarFilmeId = registrarFilme.Id;
                        vinculoAtorPersonagem.CadastroAtorId = cadastroAtor[i];
                        if (cadastroPersonagem[i] == null)
                        {
                            vinculoAtorPersonagem.NomePersonagem = "Não cadastrado";
                        }
                        else
                        {
                            vinculoAtorPersonagem.NomePersonagem = cadastroPersonagem[i];
                        }
                        _context.Add(vinculoAtorPersonagem);
                    }

                        await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrarFilmeExists(registrarFilme.Id))
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

            return View(registrarFilme);
        }

        // GET: RegistrarFilmes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrarFilme = await _context.RegistrarFilme
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registrarFilme == null)
            {
                return NotFound();
            }

            return View(registrarFilme);
        }

        // POST: RegistrarFilmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registrarFilme = await _context.RegistrarFilme.FindAsync(id);
            if (registrarFilme != null)
            {
                _context.RegistrarFilme.Remove(registrarFilme);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrarFilmeExists(int id)
        {
            return _context.RegistrarFilme.Any(e => e.Id == id);
        }
    }
}
