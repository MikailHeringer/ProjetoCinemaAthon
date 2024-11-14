using System.ComponentModel.DataAnnotations;

namespace ProjetoCinemaAthon.Models
{
    public class VinculoFilmeAtor
    {
        public int Id { get; set; }
        public int RegistrarFilmeId { get; set; }
        public int CadastroAtorId { get; set; }

        [Display(Name = "Nome do Personagem")]
        public string? NomePersonagem { get; set; }

        public RegistrarFilme? RegistrarFilme { get; set; }
        public CadastroAtor? CadastroAtor { get; set; }
    }
}
