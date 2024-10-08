namespace Library_Management.Models
{
    public class Emprunt
    {
        public int IdEmprunt { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetour { get; set; }
        public int IdUtilisateur { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public int IdLivre { get; set; }
        public Livre Livre { get; set; }
    }
}
