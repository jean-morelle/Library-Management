using Library_Management.Models;

namespace Library_Management.Repertory
{
    public interface IUtilisateurRepertory
    {
        IEnumerable<Utilisateur> GetUtilisateurs();
        public Utilisateur GetUtilisateur( int UtilisateurId);

        public void Create(Utilisateur utilisateur);

        public void Update(Utilisateur utilisateur);
        public void Delete(int UtilisateurId);
    }
}
