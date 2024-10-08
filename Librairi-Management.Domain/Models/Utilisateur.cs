namespace Library_Management.Models
{
    public class Utilisateur
    {
        public int IdUtilisateur { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public List<Emprunt> Emprunts { get; set; } = new List<Emprunt>();
    }
}
