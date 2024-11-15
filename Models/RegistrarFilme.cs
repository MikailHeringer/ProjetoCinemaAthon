using System.ComponentModel.DataAnnotations;

namespace ProjetoCinemaAthon.Models
{
    public class RegistrarFilme
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string? Titulo { get; set; }

        [Display(Name = "Data de Lançamento")]
        [DataType(DataType.Date)]
        public DateTime DtLancamento { get; set; }

        public string? Diretor { get; set; }

        [Display(Name = "Link da Capa")]
        public string? LinkCapa { get; set; }

        public ICollection<VinculoFilmeGenero>? VinculoFilmeGenero { get; set; }
        public ICollection<VinculoFilmeAtor>? VinculoFilmeAtor { get; set; }
    }
}
