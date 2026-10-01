using Library_Management.Models;

namespace Library_Management.Repertory
{
    public interface IEmpruntRepertory
    {
        Task<IEnumerable<Emprunt>> ObtenirLesLivresEmpruntersAsync();

        Task<Emprunt?> ObtenirLivreEmprunterParIdAsync(Guid Id);

        Task<bool> LivreEstEmprunteAsync(Guid livreId, Guid? empruntExcluId = null);

        Task<bool> ClientAEmpruntEnCoursAsync(Guid clientId);

        Task LivreEmprunters(Emprunt Emprunt);

        Task MettreAjoursLesLivresEprunterAsync(Emprunt emprunt);

        Task SupprimerLesLivresEmprunters(Guid Id);
    }
}
