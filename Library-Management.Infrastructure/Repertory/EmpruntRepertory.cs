using Library_Management.Data;
using Library_Management.Models;
using System.Security.Cryptography.X509Certificates;

namespace Library_Management.Repertory
{
    public class EmpruntRepertory : IEmpruntRepertory
    {
        private readonly ApplicationDbContext _context;

        public EmpruntRepertory(ApplicationDbContext context)
        {
                _context =context;
        }

        public void Create(Emprunt emprunt)
        {
             _context.Emprunts.Add(emprunt);
             _context.SaveChanges();
        }

        public void Delete(int empruntId)
        {
            _context.Emprunts.Remove(GetEmprunt(empruntId));
            _context.SaveChanges();    
        }

        public IEnumerable<Emprunt>GetEmprunts()
        {
            var emprunt = _context.Emprunts.ToList();
            return emprunt;
        }

        public Emprunt GetEmprunt(int id)
        {
           var  emprunt = _context.Emprunts.First(x => x.LivreId ==id);
            return emprunt;
        }

        public void Update(Emprunt emprunt)
        {
            _context.Emprunts.Update(emprunt);
            _context.SaveChanges();
        }
    }
}

