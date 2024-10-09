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

        public void create(Livre Livres)
        {
            _context.Livres.Add(Livres);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
             _context.Livres.Remove(GetLivreId(id));
            _context.SaveChanges();
        }

        public Livre GetLivreId(int id)
        {
            return _context.Livres.Find(id);
        }

        public IEnumerable<Livre> Livres()
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
