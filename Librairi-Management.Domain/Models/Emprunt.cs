using Librairi_Management.Domain.Models;

namespace Library_Management.Models
{
    public class Emprunt
    {
        public Guid Id { get; set; }
        public DateTime DateEmprunt { get; set; }
        // Date de retour prévue
        public DateTime DateRetour { get; set; }
        // Renseignée quand le livre est effectivement rendu
        public DateTime? DateRetourEffective { get; set; }
        public bool EstRendu => DateRetourEffective.HasValue;
        public Guid LivreId { get; set; }
        public Livre? Livre { get; set; }
        public Guid ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
