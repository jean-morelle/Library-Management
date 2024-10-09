using Library_Management.Models;

namespace Library_Management.Repertory
{
    public interface IEmpruntRepertory
    {
        IEnumerable<Emprunt> GetEmprunts();

        public Emprunt GetEmprunt(int id);

        public void Create(Emprunt emprunt);

        public void Delete(int emprunt);

        public void Update (Emprunt emprunt);
    }
}
