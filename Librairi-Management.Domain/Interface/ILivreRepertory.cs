using Library_Management.Models;

namespace Library_Management.Repertory
{
    public interface ILivreRepertory
    {
        IEnumerable<Livre>GetLivres();

        public Livre GetLivre(int id);

        public void Create(Livre Livres);

        public void Delete(int id);

        public void Update(Livre Livres);
    }
}
