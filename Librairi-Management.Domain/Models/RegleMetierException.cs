namespace Librairi_Management.Domain.Models
{
    // Levée quand une opération viole une règle de gestion (livre déjà emprunté, dates invalides...)
    public class RegleMetierException : Exception
    {
        public RegleMetierException(string message) : base(message)
        {
        }
    }
}
