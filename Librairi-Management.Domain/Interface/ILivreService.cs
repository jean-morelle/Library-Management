using Library_Management.Models;

namespace Library_Management.Service
{
    public interface ILivreService
    {
        IEnumerable<Livre>GetLivres();

        public Livre GetLivre(int id);

        public void Create(Livre livre);

        public void Update(Livre livre);

        public void Delete(int id);
    }
}
