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
    public class LivreEmpruntersServices :IEmpruntServices
    {
        private readonly IEmpruntRepertory empruntRepertory;

        public LivreEmpruntersServices(IEmpruntRepertory empruntRepertory)
        {
            this.empruntRepertory = empruntRepertory;
        }

        public async Task LivreEmprunters(Emprunt Emprunt)
        {
            await empruntRepertory.LivreEmprunters(Emprunt);
        }

        public async Task MettreAjoursLesLivresEprunterAsync(Emprunt emprunt)
        {
            await empruntRepertory.MettreAjoursLesLivresEprunterAsync(emprunt);
        }

        public Task<IEnumerable<Emprunt>> ObtenirLesLivresEmpruntersAsync()
        {
            var livreEmprunters = empruntRepertory.ObtenirLesLivresEmpruntersAsync();
            return livreEmprunters;
        }

        public Task<Emprunt> ObtenirLivreEmprunterParIdAsync(Guid Id)
        {
            var livreEmprunter = empruntRepertory.ObtenirLivreEmprunterParIdAsync(Id);
            return livreEmprunter;
        }

        public async Task SupprimerLesLivresEmprunters(Guid Id)
        {
            await empruntRepertory.SupprimerLesLivresEmprunters(Id);
        }
    }
}
