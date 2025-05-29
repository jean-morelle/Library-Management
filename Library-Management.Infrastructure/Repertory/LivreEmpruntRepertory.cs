using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management.Data;
using Library_Management.Models;
using Library_Management.Repertory;
using Microsoft.EntityFrameworkCore;

namespace Library_Management.Infrastructure.Repertory
{
    public class LivreEmpruntRepertory:IEmpruntRepertory
    {
        private readonly ApplicationDbContext applicationDbContext;

        public LivreEmpruntRepertory(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task LivreEmprunters(Emprunt Emprunt)
        {
            applicationDbContext.Emprunts.Add(Emprunt);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task MettreAjoursLesLivresEprunterAsync(Emprunt emprunt)
        {
            applicationDbContext.Emprunts.Update(emprunt);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Emprunt>> ObtenirLesLivresEmpruntersAsync()
        {
            var emprunt = await applicationDbContext.Emprunts.ToListAsync();
            return emprunt;
        }


        public async Task<Emprunt> ObtenirLivreEmprunterParIdAsync(Guid Id)
        {
            var emprunt = await applicationDbContext.Emprunts.FirstOrDefaultAsync(e => e.Id == Id);
            return emprunt;
        }

        public async Task SupprimerLesLivresEmprunters(Guid Id)
        {
            var emprunt = await applicationDbContext.Emprunts.FirstOrDefaultAsync(e => e.Id == Id);
            if(emprunt == null)
            {
                throw new KeyNotFoundException("Emprunt non trouvé");
            }
            else
            {
                applicationDbContext.Emprunts.Remove(emprunt);
                await applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
