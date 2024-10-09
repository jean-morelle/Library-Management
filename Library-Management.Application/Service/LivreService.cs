using Library_Management.Models;
using Library_Management.Repertory;

namespace Library_Management.Service
{
    public class LivreService:ILivreService
    {
        private readonly ILivreRepertory _livreRepertory;

        public LivreService(ILivreRepertory livreRepertory)
        {
            _livreRepertory = livreRepertory;
        }

        public void Create(Livre livre)
        {
            _livreRepertory.Create(livre);
        }

        public void Delete(int id)
        {
            _livreRepertory.Delete(id);
        }

        public Livre GetLivre(int id)
        {
            return _livreRepertory.GetLivre(id);
        }

        public IEnumerable<Livre> GetLivres()
        {
            return _livreRepertory.GetLivres();
        }

        public void Update(Livre livre)
        {
            _livreRepertory.Update(livre);
        }
    }
}
