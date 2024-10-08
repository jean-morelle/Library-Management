namespace Library_Management.Models
{
    public class Emprunt
    {
        public int Id { get; set; }
        public DateTime? Date_D_Empreinte { get; set; }

        public DateTime? Date_De_Retour { get; set; }
        
        public int UtilisateurId { get; set; }

        public Utilisateur utilisateur { get; set; }

       //public ICollection<EmpruntLivre> EmpruntLivre { get; set; }
    }
}
