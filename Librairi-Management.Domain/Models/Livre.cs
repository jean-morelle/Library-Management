namespace Library_Management.Models
{
    public class Livre
    {
        public int IdLivre { get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public string ISBN { get; set; }
        public List<Emprunt> Emprunts { get; set; } = new List<Emprunt>();
    }
}
