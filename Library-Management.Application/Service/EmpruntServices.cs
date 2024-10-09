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

        public void Create(Emprunt emprunt)
        {
            _empruntRepertory.Create(emprunt);
            
        }

        public void Delete(int emprund)
        {
            _empruntRepertory.Delete(emprund);
        }

      

        public Emprunt GetEmprunt(int empruntId)
        {
            return _empruntRepertory.GetEmprunt(empruntId);
        }

        public IEnumerable<Emprunt> GetEmprunts()
        {
            return _empruntRepertory.GetEmprunts();
        }

        public void Update(Emprunt emprunt)
        {
            _empruntRepertory.Update(emprunt);
        }
    }
}

