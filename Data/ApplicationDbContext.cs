using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoCinemaAthon.Models;

namespace ProjetoCinemaAthon.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProjetoCinemaAthon.Models.RegistrarFilme> RegistrarFilme { get; set; } = default!;
        public DbSet<ProjetoCinemaAthon.Models.CadastroGenero> CadastroGenero { get; set; } = default!;
        public DbSet<ProjetoCinemaAthon.Models.CadastroAtor> CadastroAtor { get; set; } = default!;
        public DbSet<ProjetoCinemaAthon.Models.VinculoAtorPersonagem> VinculoAtorPersonagem { get; set; } = default!;
        public DbSet<ProjetoCinemaAthon.Models.VinculoFilmeGenero> VinculoFilmeGenero { get; set; } = default!;
        public DbSet<ProjetoCinemaAthon.Models.VinculoFilmeAtor> VinculoFilmeAtor { get; set; } = default!;
        public DbSet<ProjetoCinemaAthon.Models.Contato> Contato { get; set; } = default!;
        public DbSet<ProjetoCinemaAthon.Models.Pesquisa> Pesquisa { get; set; } = default!;
    }
}
