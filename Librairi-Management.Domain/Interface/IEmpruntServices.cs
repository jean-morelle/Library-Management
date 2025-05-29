using Library_Management.Models;

namespace Library_Management.Service
{
    public interface IEmpruntServices
    {
        Task<IEnumerable<Emprunt>> ObtenirLesLivresEmpruntersAsync();

        Task<Emprunt> ObtenirLivreEmprunterParIdAsync(Guid Id);

        Task LivreEmprunters(Emprunt Emprunt);

        Task MettreAjoursLesLivresEprunterAsync(Emprunt emprunt);

        Task SupprimerLesLivresEmprunters(Guid Id);

    }
}
