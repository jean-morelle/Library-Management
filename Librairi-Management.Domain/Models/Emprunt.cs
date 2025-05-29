using Librairi_Management.Domain.Models;

namespace Library_Management.Models
{
    public class Emprunt
    {
        public Guid Id { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetour { get; set; }
        public Guid LivreId { get; set; }
        public Livre Livre { get; set; } 
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}
