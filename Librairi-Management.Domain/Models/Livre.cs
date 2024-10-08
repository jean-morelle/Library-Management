namespace Library_Management.Models
{
    public class Livre
    {
        public int Id { get; set; }
        public string Title  { get; set; }

        public string Nom_Auteur { get; set; }
        public DateTime? Annee_De_Publication { get; set; }

       //public ICollection<EmpruntLivre> EmpruntLivre { get; set; }
    }
}
