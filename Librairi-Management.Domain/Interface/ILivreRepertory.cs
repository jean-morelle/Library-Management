using Library_Management.Models;

namespace Library_Management.Repertory
{
    public interface ILivreRepertory
    {
        Task<IEnumerable<Livre>> ObtenirLesLivresAsync();
        Task<Livre>ObtenirLivreParIdAsync(Guid Id);
        Task AjouterLivreAsync(Livre Livre);
        Task SupprimerLivreAsync(Guid Id);
        Task MettreAjoursLivreAsync(Livre livre);
    }
}
