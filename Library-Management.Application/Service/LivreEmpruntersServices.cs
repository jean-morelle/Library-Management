using Librairi_Management.Domain.Interface;
using Librairi_Management.Domain.Models;
using Library_Management.Models;
using Library_Management.Repertory;
using Library_Management.Service;

namespace Library_Management.Application.Service
{
    public class LivreEmpruntersServices :IEmpruntServices
    {
        private readonly IEmpruntRepertory empruntRepertory;
        private readonly ILivreRepertory livreRepertory;
        private readonly IClientRepertory clientRepertory;

        public LivreEmpruntersServices(IEmpruntRepertory empruntRepertory, ILivreRepertory livreRepertory, IClientRepertory clientRepertory)
        {
            this.empruntRepertory = empruntRepertory;
            this.livreRepertory = livreRepertory;
            this.clientRepertory = clientRepertory;
        }

        public async Task LivreEmprunters(Emprunt Emprunt)
        {
            await VerifierEmpruntAsync(Emprunt, null);
            await empruntRepertory.LivreEmprunters(Emprunt);
        }

        public async Task MettreAjoursLesLivresEprunterAsync(Emprunt emprunt)
        {
            await VerifierEmpruntAsync(emprunt, emprunt.Id);
            await empruntRepertory.MettreAjoursLesLivresEprunterAsync(emprunt);
        }

        public async Task RetournerLivreAsync(Guid Id)
        {
            var emprunt = await empruntRepertory.ObtenirLivreEmprunterParIdAsync(Id)
                ?? throw new KeyNotFoundException("Emprunt non trouvé");

            if (emprunt.EstRendu)
            {
                throw new RegleMetierException("Ce livre a déjà été rendu.");
            }

            emprunt.DateRetourEffective = DateTime.Now;
            await empruntRepertory.MettreAjoursLesLivresEprunterAsync(emprunt);
        }

        public Task<IEnumerable<Emprunt>> ObtenirLesLivresEmpruntersAsync()
        {
            return empruntRepertory.ObtenirLesLivresEmpruntersAsync();
        }

        public Task<Emprunt?> ObtenirLivreEmprunterParIdAsync(Guid Id)
        {
            return empruntRepertory.ObtenirLivreEmprunterParIdAsync(Id);
        }

        public async Task SupprimerLesLivresEmprunters(Guid Id)
        {
            await empruntRepertory.SupprimerLesLivresEmprunters(Id);
        }

        private async Task VerifierEmpruntAsync(Emprunt emprunt, Guid? empruntId)
        {
            if (emprunt.DateRetour.Date < emprunt.DateEmprunt.Date)
            {
                throw new RegleMetierException("La date de retour doit être postérieure à la date d'emprunt.");
            }
            if (await livreRepertory.ObtenirLivreParIdAsync(emprunt.LivreId) is null)
            {
                throw new RegleMetierException("Le livre sélectionné n'existe pas.");
            }
            if (await clientRepertory.ObtenirClientParId(emprunt.ClientId) is null)
            {
                throw new RegleMetierException("Le client sélectionné n'existe pas.");
            }
            if (!emprunt.EstRendu && await empruntRepertory.LivreEstEmprunteAsync(emprunt.LivreId, empruntId))
            {
                throw new RegleMetierException("Ce livre est déjà emprunté.");
            }
        }
    }
}
