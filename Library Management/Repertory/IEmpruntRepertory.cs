using Library_Management.Models;

namespace Library_Management.Repertory
{
    public interface IEmpruntRepertory
    {
        IEnumerable<Emprunt> Emprunts();

        public Emprunt GetEmpruntId(int id);

        public void create(Emprunt emprunt);

        public void delete(int emprunt);

        public void update (Emprunt emprunt);
    }
}
