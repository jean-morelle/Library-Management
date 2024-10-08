using Library_Management.Models;

namespace Library_Management.Service
{
    public interface ILivreService
    {
        IEnumerable<Livre> Livres();

        public Livre GetLivreId(int id);

        public void create(Livre livre);

        public void update(Livre livre);

        public void delete(int id);
    }
}
