using System.ComponentModel.DataAnnotations;

namespace ProjetoCinemaAthon.Models
{
    public class CadastroAtor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatório.")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DtNascimento { get; set; }

        [Display(Name = "País Nascimento")]
        public string? PaisNascimento { get; set; }

        [Display(Name = "Foto do Artista")]
        public string? FotoArtista { get; set; }

        public ICollection<VinculoFilmeAtor>? VinculoFilmeAtor { get; set; }
        public ICollection<VinculoAtorPersonagem>? VinculoAtorPersonagem { get; set; }
    }
}
