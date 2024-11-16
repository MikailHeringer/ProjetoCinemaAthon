namespace ProjetoCinemaAthon.Models
{
    public class VinculoAtorPersonagem
    {
        public int Id { get; set; }
        public string NomePersonagem { get; set; }
        public int RegistrarFilmeId { get; set; }
        public int CadastroAtorId { get; set; }

        public RegistrarFilme? RegistrarFilme { get; set; }
        public CadastroAtor? CadastroAtor { get; set; }
    }
}
