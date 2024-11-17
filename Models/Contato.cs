using System.ComponentModel.DataAnnotations;

namespace ProjetoCinemaAthon.Models
{
    public class Contato
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [Display(Name = "Nome Completo")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress]
        [Display(Name = "E-mail para Contato")]
        public string? Email { get; set; }

        [Display(Name = "Assunto")]
        public string? Assunto { get; set; }

        [Display(Name = "Mensagem")]
        public string? Mensagem { get; set; }

        public DateTime DataEnvio { get; set; } = DateTime.Now;
    }
}
