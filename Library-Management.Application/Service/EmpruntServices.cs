using Library_Management.Models;
using Library_Management.Repertory;

namespace Library_Management.Service
{
    public class EmpruntServices : IEmpruntServices
    {
        private readonly IEmpruntRepertory _empruntRepertory;

        public EmpruntServices(IEmpruntRepertory empruntRepertory)
        {
            _empruntRepertory = empruntRepertory;
        }

        public void create(Emprunt emprunt)
        {
            _empruntRepertory.create(emprunt);
            
        }

        public void delete(int emprund)
        {
            _empruntRepertory.delete(emprund);
        }

      

        public Emprunt GetEmpruntId(int empruntId)
        {
            return _empruntRepertory.GetEmpruntId(empruntId);
        }

        public IEnumerable<Emprunt> GetEmprunts()
        {
            return _empruntRepertory.Emprunts();
        }

        public void update(Emprunt emprunt)
        {
            _empruntRepertory.update(emprunt);
        }
    }
}

namespace Library_Management.Application
{
    public class UtilisateurRepertory
    {
    }
}