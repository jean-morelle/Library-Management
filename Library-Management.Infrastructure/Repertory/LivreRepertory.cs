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
    public class LivreRepertory:ILivreRepertory
    {
        private readonly ApplicationDbContext applicationDbContext;

        public LivreRepertory(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AjouterLivreAsync(Livre Livre)
        {
            applicationDbContext.Livres.Add(Livre);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task MettreAjoursLivreAsync(Livre livre)
        {
            applicationDbContext.Livres.Update(livre);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Livre>> ObtenirLesLivresAsync()
        {
            var livres = await applicationDbContext.Livres.ToListAsync();
            return livres;
        }

        public Task<Livre> ObtenirLivreParIdAsync(Guid Id)
        {
            var livre = applicationDbContext.Livres.FirstOrDefaultAsync(l => l.Id == Id);
            return livre;
        }

        public async Task SupprimerLivreAsync(Guid id)
        {
            var livre = await applicationDbContext.Livres.FirstOrDefaultAsync(l => l.Id == id);

            if (livre == null)
            {
                throw new KeyNotFoundException("Livre non trouvé");
            }

            applicationDbContext.Livres.Remove(livre);
            await applicationDbContext.SaveChangesAsync();
        }

    }
}
