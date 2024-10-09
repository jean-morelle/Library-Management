using Library_Management.Data;
using Library_Management.Models;

namespace Library_Management.Repertory
{
    public class LivreRepertory :ILivreRepertory
    {
        private readonly ApplicationDbContext _context;

        public LivreRepertory(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Livre Livres)
        {
            _context.Livres.Add(Livres);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
             _context.Livres.Remove(GetLivre(id));
            _context.SaveChanges();
        }

        public Livre GetLivre(int id)
        {
            return _context.Livres.First(x => x.LivreId == id);
        }

        public IEnumerable<Livre> GetLivres()
        {
            return _context.Livres.ToList();
        }

        public void Update(Livre Livres)
        {
            _context.Livres.Update(Livres);
            _context.SaveChanges();
        }
    }
}
