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

        // Les emprunts sont chargés pour pouvoir calculer la disponibilité du livre
        public async Task<IEnumerable<Livre>> ObtenirLesLivresAsync()
        {
            return await applicationDbContext.Livres
                .Include(l => l.Emprunts)
                .OrderBy(l => l.Titre)
                .ToListAsync();
        }

        public async Task<Livre?> ObtenirLivreParIdAsync(Guid Id)
        {
            return await applicationDbContext.Livres
                .Include(l => l.Emprunts)
                .FirstOrDefaultAsync(l => l.Id == Id);
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
