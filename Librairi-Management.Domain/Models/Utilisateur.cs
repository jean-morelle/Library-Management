namespace Library_Management.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Mot_De_Passe {  get; set; }

        public string Gmail { get; set; }

        public DateTime? DateCreationCompte { get; set; }

       //public ICollection<Emprunt> Emprunts { get; set;}
    }
}
