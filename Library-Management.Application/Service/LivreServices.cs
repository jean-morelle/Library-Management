using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management.Models;
using Library_Management.Repertory;
using Library_Management.Service;

namespace Library_Management.Application.Service
{
    public class LivreServices:ILivreService
    {
        private readonly ILivreRepertory livreRepertory;

        public LivreServices(ILivreRepertory livreRepertory)
        {
            this.livreRepertory = livreRepertory;
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
            var livres = livreRepertory.ObtenirLesLivresAsync();
            return livres;
        }

        public async Task<Livre> ObtenirLivreParIdAsync(Guid Id)
        {
            var livre = await livreRepertory.ObtenirLivreParIdAsync(Id);
            return livre;
        }

        public async Task SupprimerLivreAsync(Guid Id)
        {
            await livreRepertory.SupprimerLivreAsync(Id);
        }
    }
}
