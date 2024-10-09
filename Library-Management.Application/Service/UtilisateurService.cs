using Library_Management.Models;
using Library_Management.Repertory;

namespace Library_Management.Service
{
    public class UtilisateurService:IUtilisateurService
    {
        private readonly IUtilisateurRepertory _utilisateurRepertory;

        public UtilisateurService( IUtilisateurRepertory utilisateurRepertory)
        {
            _utilisateurRepertory = utilisateurRepertory;
        }

        public void Create(Utilisateur utilisateur)
        {
            _utilisateurRepertory.Create(utilisateur);
            
        }

        public void Delete(int UtilisateurId)
        {
            _utilisateurRepertory.Delete(UtilisateurId);
        }

        public Utilisateur GetUtilisateur(int UtilisateurId)
        {
            return _utilisateurRepertory.GetUtilisateur(UtilisateurId);
        }

        public IEnumerable<Utilisateur> GetUtilisateurs()
        {
            return _utilisateurRepertory.GetUtilisateurs();
        }

        public void Update(Utilisateur utilisateur)
        {
            _utilisateurRepertory.Update(utilisateur);
        }
    }
}
