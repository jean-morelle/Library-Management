using Library_Management.Models;

namespace Library_Management.Service
{
    public interface IEmpruntServices
    {
        IEnumerable<Emprunt> GetEmprunts();

        public Emprunt GetEmpruntId(int empruntId);

        public void create(Emprunt emprunt);

        public void delete(int emprund);

        public void update(Emprunt emprunt);
   
    }
}
