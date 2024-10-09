using Library_Management.Data;
using Library_Management.Models;
using System.Security.Cryptography.X509Certificates;

namespace Library_Management.Repertory
{
    public class EmpruntRepertory : IEmpruntRepertory
    {
        private readonly ApplicationDbContext _Context;

        public EmpruntRepertory(ApplicationDbContext context)
        {
                _Context =context;
        }

        public void Create(Emprunt emprunt)
        {
             _Context.Emprunts.Add(emprunt);
             _Context.SaveChanges();
        }

        public void Delete(int empruntId)
        {
            _Context.Emprunts.Remove(GetEmprunt(empruntId));
            _Context.SaveChanges();    
        }

        public IEnumerable<Emprunt>GetEmprunts()
        {
            var emprunt = _Context.Emprunts.ToList();
            return emprunt;
        }

        public Emprunt GetEmprunt(int id)
        {
           var  emprunt = _Context.Emprunts.First(x => x.LivreId ==id);
            return emprunt;
        }

        public void Update(Emprunt emprunt)
        {
            _Context.Emprunts.Update(emprunt);
            _Context.SaveChanges();
        }
    }
}

