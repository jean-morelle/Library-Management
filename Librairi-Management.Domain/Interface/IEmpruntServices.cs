using Library_Management.Models;

namespace Library_Management.Service
{
    public interface IEmpruntServices
    {
        IEnumerable<Emprunt> GetEmprunts();

        public Emprunt GetEmprunt(int empruntId);

        public void Create(Emprunt emprunt);

        public void Delete(int emprund);

        public void Update(Emprunt emprunt);
   
    }
}
