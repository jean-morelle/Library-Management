using Library_Management.Data;
using Library_Management.Models;

namespace Library_Management.Repertory
{
    public class UtilisateurRepertory:IUtilisateurRepertory
    {
        private readonly ApplicationDbContext _context;

        public UtilisateurRepertory( ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Utilisateur utilisateur)
        {
            _context.Utilisateurs.Add(utilisateur);
            _context.SaveChanges();
        }

        public void Delete(int UtilisateurId)
        {
            var utilisateur = _context.Utilisateurs.Find(UtilisateurId);
            if (utilisateur != null)
            {
                _context.Utilisateurs.Remove(utilisateur);
                _context.SaveChanges();
            }
        }

        public Utilisateur GetUtilisateurById(int UtilisateurId)
        {
            return _context.Utilisateurs.Find(UtilisateurId);
        }

        public IEnumerable<Utilisateur> GetUtilisateurs()
        {
            return _context.Utilisateurs.ToList();
        }

        public void Update(Utilisateur utilisateur)
        {
            _context.Utilisateurs.Update(utilisateur);
            _context.SaveChanges();
        }
    }
}
