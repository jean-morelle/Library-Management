using Library_Management.Models;

namespace Library_Management.Repertory
{
    public interface ILivreRepertory
    {
        IEnumerable<Livre> Livres();

        public Livre GetLivreId(int id);

        public void create(Livre Livres);

        public void Delete(int id);

        public void Update(Livre Livres);
    }
}
