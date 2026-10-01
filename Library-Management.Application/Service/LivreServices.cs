using Librairi_Management.Domain.Models;
using Library_Management.Models;
using Library_Management.Repertory;
using Library_Management.Service;

namespace Library_Management.Application.Service
{
    public class LivreServices:ILivreService
    {
        private readonly ILivreRepertory livreRepertory;
        private readonly IEmpruntRepertory empruntRepertory;

        public LivreServices(ILivreRepertory livreRepertory, IEmpruntRepertory empruntRepertory)
        {
            this.livreRepertory = livreRepertory;
            this.empruntRepertory = empruntRepertory;
        }

        public async Task AjouterLivreAsync(Livre Livre)
        {
            await livreRepertory.AjouterLivreAsync(Livre);
        }

        public async Task MettreAjoursLivreAsync(Livre livre)
        {
            await livreRepertory.MettreAjoursLivreAsync(livre);
        }

        public Task<IEnumerable<Livre>> ObtenirLesLivresAsync()
        {
            return livreRepertory.ObtenirLesLivresAsync();
        }

        public Task<Livre?> ObtenirLivreParIdAsync(Guid Id)
        {
            return livreRepertory.ObtenirLivreParIdAsync(Id);
        }

        public async Task SupprimerLivreAsync(Guid Id)
        {
            if (await empruntRepertory.LivreEstEmprunteAsync(Id))
            {
                throw new RegleMetierException("Impossible de supprimer un livre actuellement emprunté.");
            }
            await livreRepertory.SupprimerLivreAsync(Id);
        }
    }
}
