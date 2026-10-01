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
            return await applicationDbContext.Emprunts
                .Include(e => e.Livre)
                .Include(e => e.Client)
                .OrderByDescending(e => e.DateEmprunt)
                .ToListAsync();
        }

        public async Task<Emprunt?> ObtenirLivreEmprunterParIdAsync(Guid Id)
        {
            return await applicationDbContext.Emprunts
                .Include(e => e.Livre)
                .Include(e => e.Client)
                .FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<bool> LivreEstEmprunteAsync(Guid livreId, Guid? empruntExcluId = null)
        {
            return await applicationDbContext.Emprunts.AnyAsync(e =>
                e.LivreId == livreId
                && e.DateRetourEffective == null
                && (empruntExcluId == null || e.Id != empruntExcluId));
        }

        public async Task<bool> ClientAEmpruntEnCoursAsync(Guid clientId)
        {
            return await applicationDbContext.Emprunts.AnyAsync(e =>
                e.ClientId == clientId && e.DateRetourEffective == null);
        }

        public async Task SupprimerLesLivresEmprunters(Guid Id)
        {
            var emprunt = await applicationDbContext.Emprunts.FirstOrDefaultAsync(e => e.Id == Id);
            if(emprunt == null)
            {
                throw new KeyNotFoundException("Emprunt non trouvé");
            }

            applicationDbContext.Emprunts.Remove(emprunt);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
