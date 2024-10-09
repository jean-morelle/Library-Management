using Library_Management.Models;

namespace Library_Management.Service
{
    public interface IUtilisateurService
    {
        IEnumerable<Utilisateur> GetUtilisateurs();

        public Utilisateur GetUtilisateur(int UtilisateurId);

        public void Create(Utilisateur utilisateur);

        public void Update(Utilisateur utilisateur);

        public void Delete(int UtilisateurId);
    }
}
