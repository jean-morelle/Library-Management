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

        public void create(Livre livre)
        {
            _livreRepertory.create(livre);
        }

        public void delete(int id)
        {
            _livreRepertory.Delete(id);
        }

        public Livre GetLivreId(int id)
        {
            return _livreRepertory.GetLivreId(id);
        }

        public IEnumerable<Livre> Livres()
        {
            return _livreRepertory.Livres();
        }

        public void update(Livre livre)
        {
            _livreRepertory.Update(livre);
        }
    }
}
