namespace Library_Management.Application.AutoMapper.Dto
{
    public class LivreEmpruntReadDto
    {
        public Guid Id { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetour { get; set; }
        public DateTime? DateRetourEffective { get; set; }
        public bool EstRendu { get; set; }
        public bool EnRetard { get; set; }
        public Guid LivreId { get; set; }
        public string TitleLivre { get; set; } = string.Empty;
        public string AuteurLivre { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public Guid ClientId { get; set; }
        public string NomClient { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Quartier { get; set; } = string.Empty;
    }
}
