namespace Library_Management.Models
{
    public class Emprunt
    {
        public int EmpruntId { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetour { get; set; }
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public int LivreId { get; set; }
        public Livre Livre { get; set; }
    }
}
