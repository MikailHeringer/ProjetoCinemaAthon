using System.ComponentModel.DataAnnotations;

namespace ProjetoCinemaAthon.Models
{
    public class CadastroGenero
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        public ICollection<VinculoFilmeGenero>? VinculoFilmeGenero { get; set; }
    }
}
