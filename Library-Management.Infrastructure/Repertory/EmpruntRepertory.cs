using Library_Management.Data;
using Library_Management.Models;

namespace Library_Management.Repertory
{
    public class EmpruntRepertory : IEmpruntRepertory
    {
        private readonly ApplicationDbContext _Context;

        public EmpruntRepertory(ApplicationDbContext context)
        {
                _Context =context;
        }

        public void create(Emprunt emprunt)
        {
             _Context.Emprunts.Add(emprunt);
             _Context.Emprunts.SaveChanges();
        }

        public void delete(int emprunt)
        {
            _Context.Emprunts.Remove(GetEmpruntId(emprunt));
            _Context.Emprunts.SaveChanges();    
        }

        public IEnumerable<Emprunt> Emprunts()
        {
            return _Context.Emprunts.ToList();
        }

        public Emprunt GetEmpruntId(int id)
        {
            return _Context.Emprunts.Find(id);
        }

        public void update(Emprunt emprunt)
        {
            _Context.Emprunts.Update(emprunt);
            _Context.Emprunts.savechange();
        }
    }
}

