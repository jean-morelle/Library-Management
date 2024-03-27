namespace Library_Management.Models
{
    public class EmpruntLivre
    {
        public int Id { get; set; }
        public int EmpruntId { get; set; }
        public int LivreId { get; set; }

        public Emprunt Emprunt { get; set; }

        public Livre Livre { get; set;}
    }
}
