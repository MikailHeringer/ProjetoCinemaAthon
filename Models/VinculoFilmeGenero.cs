namespace ProjetoCinemaAthon.Models
{
    public class VinculoFilmeGenero
    {
        public int Id { get; set; }
        public int RegistrarFilmeId { get; set; }
        public int CadastroGeneroId { get; set; }

        public RegistrarFilme? RegistrarFilme { get; set; }
        public CadastroGenero? CadastroGenero { get; set; }
    }

}
